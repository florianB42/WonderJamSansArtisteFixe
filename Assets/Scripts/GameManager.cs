using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;


public class GameManager : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerController playerController;
    private Player player;
    public AIMonster Reaper;
    private static GameManager _instance;
    
    private static float TimerReaper;
    private float PlayerTimer;
    private float ReaperTimer;
    private static float TimerPlayer;
    private bool PlayerTurn;
    public int chestOpened;
    private bool playerGotKeyGold;

    private GameObject InteractionBar;
    private static float InteractionTimer;
    private bool InteractTimerON;
    private Interactable InteractWith;
    private Item itemInUse;

    public SliderController timeSlider;
    public SliderController resistanceSider;

    public PopupItemFund dialogManager;
     public DialogTurnController dialogTurn;

    public Light2D globalLight;
    public bool lightingMatch;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        TimerPlayer = 30; ///////Constante
        TimerReaper = 10;
        PlayerTimer = TimerPlayer;
        ReaperTimer = 0;
        PlayerTurn = true;
        chestOpened = 0;
        playerGotKeyGold = false;

        InteractTimerON = false;
        InteractionTimer = 0;

        lightingMatch = false;

        timeSlider.SetMaxValue(TimerPlayer);

        player = playerObject.GetComponent<Player>();
        playerController = playerObject.GetComponent<PlayerController>();

        addItemInPlayerInventory();

        InteractionBar = GameObject.Find("InteractionBar");
        InteractionBar.SetActive(false);

        dialogManager.hide();
        dialogTurn.hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTurn)
        {
            PlayerTimer -= Time.deltaTime;
            timeSlider.SetValue(PlayerTimer);

            resistanceSider.SetValue(player.resistance);

            if (PlayerTimer < 0)
            {
                Debug.Log("Tour du joueur fini");
                playerController.stopPlayer();
                Reaper.restartMonster();
                ReaperTimer = TimerReaper; 
                PlayerTurn = !PlayerTurn;
            }

            if(InteractTimerON)
            {
                playerController.stopPlayer();
                InteractionTimer -= Time.deltaTime;

                 SliderController slidercontroller = GameObject.Find("InteractionBar").GetComponent<SliderController>();

                slidercontroller.SetValue(InteractionTimer);

                if(InteractionTimer < 0)
                {
                    InteractTimerON = false;
                    ResultInteraction();
                    playerController.restartPlayer();
                    playerController.resetInteraction();
                    Debug.Log("Je suis passé par un timer ");
                }
            }

        }
        else
        {

         if (!dialogTurn.isActiveAndEnabled)
            {
                dialogTurn.StartDialogue("The Reaper is chasing you.");
            }

            ReaperTimer -= Time.deltaTime;
            if (ReaperTimer < 0)
            {
                Debug.Log("Tour du Reaper fini");
                playerController.restartPlayer();
                Reaper.stopMonster();
                PlayerTimer = TimerPlayer;
                PlayerTurn = !PlayerTurn;
                dialogTurn.StartDialogue("Run.");
            }
        }

        if(lightingMatch && globalLight.intensity < 0.5f)
        {
            globalLight.intensity += 0.01f;
        }
        else if(!lightingMatch && globalLight.intensity > 0.25f)
        {
            globalLight.intensity -= 0.01f;
        }
    }

    public void LaunchTimerInteraction(Item item, Interactable interact)
    {
        if (item == null)
        {
            playerController.resetInteraction();
            return;
        }
        InteractionTimer = item.UseTime;
        InteractWith = interact;
        InteractionBar.SetActive(true);
        SliderController slidercontroller = GameObject.Find("InteractionBar").GetComponent< SliderController>();
        
        slidercontroller.SetMaxValue(item.UseTime);

        InteractTimerON = true;
        itemInUse = item;
        UpdateInventory();
    }

    private void ResultInteraction()
    {
        InteractWith.valideOpenning();
        switch (InteractWith.interactableName)
        {
            case InteracibleItem.CHEST:
                Item itemToAdd = RandomLoot();
                if (itemToAdd != null) 
                    dialogManager.StartDialogue(itemToAdd);
                if (itemToAdd != null && 
                    itemToAdd.name != ItemType.SPIDER && 
                    itemToAdd.name != ItemType.HEAD)
                {
                    player.inventaire.Add(itemToAdd);
                }

                chestOpened++;
                break;

            case InteracibleItem.SELF:
                switch(itemInUse.name)
                {
                    case ItemType.MATCH:
                        lightingMatch = true;
                        Invoke("TurnOffMatch", 10);
                        //player.GetComponent<ResistanceComponent>().PlusResistance(20);
                        break;
                    case ItemType.TEDDY:
                        player.GetComponent<ResistanceComponent>().PlusResistance(100);
                        break;
                }
                break;
        }
        InteractionBar.SetActive(false);
    }
    private void TurnOffMatch()
    {
        lightingMatch = false;
    }


    private Item RandomLoot()
    {
      float random = UnityEngine.Random.Range(0f, 1f);
      Item itemToAdd = null;
      int multiplicateur = 0;

      if (chestOpened > 5)
          multiplicateur = 2;
      if (chestOpened > 10)
          multiplicateur = 8;
      if (chestOpened > 15)
          multiplicateur = 20;
      if (chestOpened > 20)
          multiplicateur = 60;
      if (chestOpened > 25)
          multiplicateur = 100;


        if (random < (0.01 * multiplicateur) && !playerGotKeyGold)
        {
            itemToAdd = new GoldKeyItem(this);
            playerGotKeyGold = true;
        }
        else if (random < 0.2)
        {
            itemToAdd = new HeadItem(this);
            player.GetComponent<ResistanceComponent>().MinusResistance(30);
        }       
        else if (random < 0.3)
        {
            itemToAdd = new CrowbarItem(this);
            chestOpened += 5;
        }        
        else if (random < 0.4)
            itemToAdd = new TeddyItem(this);
        else if (random < 0.5)
            itemToAdd = new MatchItem(this);
        else if (random < 0.6)
        {
            itemToAdd = new SpiderItem(this);
            player.GetComponent<ResistanceComponent>().MinusResistance(30);
        }
        else if (random < 0.8)
            itemToAdd = new HammerItem(this);
        else if (random <= 1)
            itemToAdd = new KeyItem(this);

        if (itemToAdd != null)
          Debug.Log("J'ai trouve" + itemToAdd.name);

      return itemToAdd;
    }

    private void UpdateInventory()
    {
        itemInUse.durability--;

        if (itemInUse.durability == 0)
            player.inventaire.Remove(itemInUse);
    }

    private void addItemInPlayerInventory()
    {
        player.inventaire.Add(new KeyItem(this));
        player.inventaire.Add(new KeyItem(this));
        player.inventaire.Add(new KeyItem(this));
        player.inventaire.Add(new KeyItem(this));
        player.inventaire.Add(new HammerItem(this));
        player.inventaire.Add(new MatchItem(this));
        player.inventaire.Add(new TeddyItem(this));
        player.inventaire.Add(new HandItem(this));
    }
}
