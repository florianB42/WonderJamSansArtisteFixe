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
        Timer = 10;
        PlayerTimer = Timer;
        ReaperTimer = 0;
        PlayerTurn = true;

        InteractTimerON = false;
        InteractionTimer = 0;

        timeSlider.maxValue = 10;
        resistanceSider.maxValue = 1;

        player = playerObject.GetComponent<Player>();
        playerController = playerObject.GetComponent<PlayerController>();

        addItemInPlayerInventory();
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
                }
            }
            else
                playerController.restartPlayer();

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
        Debug.Log("Choix : "+item.name);
        InteractionTimer = item.UseTime;
        InteractWith = interact;
        InteractTimerON = true;
        itemInUse = item;
        UpdateInventory();
    }

    private void ResultInteraction()
    {
        switch (InteractWith.interactableName)
        {
            case InteracibleItem.CHEST:
                Item itemToAdd = RandomLoot();
                if (itemToAdd != null)
                    player.inventaire.Add(itemToAdd);
                //TODO afficher popup
                break;

            case InteracibleItem.DOOR:

                break;
        }
    }

    private Item RandomLoot()
    {
        float random = UnityEngine.Random.Range(0f, 1f);
        Item itemToAdd = null;

        if (random < 0.2)
            itemToAdd = new KeyItem(this);
        else if (random < 0.4)
            itemToAdd = new HammerItem(this);
        //else if (random < 0.6)
        //new KeyItem(this);
        if(itemToAdd != null)
            Debug.Log("J'ai trouv�" + itemToAdd.name);

        return null;
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
    }
}
