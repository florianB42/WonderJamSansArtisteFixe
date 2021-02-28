using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerController playerController;
    private Player player;
    public AIMonster Reaper;
    private static GameManager _instance;

    private float PlayerTimer;
    private float ReaperTimer;
    private static float Timer;
    private bool PlayerTurn;

    private static float InteractionTimer;
    private bool InteractTimerON;
    private Interactable InteractWith;
    private Item itemInUse;

    public SliderController timeSlider;
    public SliderController resistanceSider;

    public PopupItemFund dialogManager;
    
    private GameObject InteractionBar;
    private int chestOpened;
    private bool playerGotKeyGold;

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
        Timer = 20;
        PlayerTimer = Timer;
        ReaperTimer = 0;
        PlayerTurn = true;
        chestOpened = 0;
        playerGotKeyGold = false;

        InteractTimerON = false;
        InteractionTimer = 0;

        timeSlider.SetMaxValue(20);

        player = playerObject.GetComponent<Player>();
        playerController = playerObject.GetComponent<PlayerController>();

        addItemInPlayerInventory();

        InteractionBar = GameObject.Find("InteractionBar");
        InteractionBar.SetActive(false);

        dialogManager.hide();
    }

    // Update is called once per frame
    void Update()
    {
        // possibilite de gerer les input ici
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
                ReaperTimer = Timer;
                PlayerTurn = !PlayerTurn;
            }

            if(InteractTimerON)
            {
                playerController.stopPlayer();
                InteractionTimer -= Time.deltaTime;
                if(InteractionTimer < 0)
                {
                    InteractTimerON = false;
                    ResultInteraction();
                    playerController.restartPlayer();
                    playerController.resetInteraction();
                }
            }

        }
        else
        {
            ReaperTimer -= Time.deltaTime;
            if (ReaperTimer < 0)
            {
                Debug.Log("Tour du Reaper fini");
                playerController.restartPlayer();
                Reaper.stopMonster();
                PlayerTimer = Timer;
                PlayerTurn = !PlayerTurn;
            }
        }
    }

    public void LaunchTimerInteraction(Item item, Interactable interact)
    {
        if (item == null)
        {
            playerController.resetInteraction();
            return;
        }

        Debug.Log("Choix : "+item.name);
        InteractionTimer = item.UseTime;
        InteractWith = interact;

        InteractionBar.SetActive(true);
        SliderController slidercontroller = GameObject.Find("InteractionBar").GetComponent< SliderController>();
        
        slidercontroller.SetMaxValue(item.UseTime);

        InteractTimerON = true;
        itemInUse = item;
        UpdateInventory();
        switch (item.name)
        {
            case ItemType.MATCH :

                break;
        }
    }

    private void ResultInteraction()
    {
        InteractWith.valideOpenning();
        switch (InteractWith.interactableName)
        {
            case InteracibleItem.CHEST:
                Item itemToAdd = RandomLoot();
                if (itemToAdd != null)
                {
                    player.inventaire.Add(itemToAdd);
                    dialogManager.StartDialogue(itemToAdd);
                }

                chestOpened++;
                break;

            case InteracibleItem.DOOR:

                break;

            case InteracibleItem.SELF:

                break;
        }
        InteractionBar.SetActive(false);
    }

    private Item RandomLoot()
    {
      float random = UnityEngine.Random.Range(0f, 1f);
      Item itemToAdd = null;
      int multiplicateur = 1;

      if (chestOpened > 5)
          multiplicateur = 2;
      if (chestOpened > 10)
          multiplicateur = 6;
      if (chestOpened > 15)
          multiplicateur = 10;
      if (chestOpened > 20)
          multiplicateur = 40;
      if (chestOpened > 20)
          multiplicateur = 50;

      if (random < (0.02 * multiplicateur) && !playerGotKeyGold)
      {
          itemToAdd = new GoldKeyItem(this);
          playerGotKeyGold = true;
      }
      else if (random < 0.2)
          itemToAdd = new HammerItem(this);
      else if (random < 0.3)
          itemToAdd = new CrowbarItem(this);
      else if (random < 0.4)
          itemToAdd = new TeddyItem(this);
      else if (random < 0.5)
          itemToAdd = new MatchItem(this);
      else if (random < 0.6)
          itemToAdd = new SpiderItem(this);
      else if (random < 0.7)
          itemToAdd = new HeadItem(this);
      else if (random <= 1)
          itemToAdd = new KeyItem(this);
      //else if (random < 0.6)
      //new KeyItem(this);
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
        player.inventaire.Add(new HammerItem(this));
        player.inventaire.Add(new MatchItem(this));
        player.inventaire.Add(new TeddyItem(this));
    }
}

