using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    KEY = 1, GOLDKEY = 2, CROWBAR = 4, HAMMER = 8
}

public class Item
{
    public ItemType name { get; protected set; }

    public int durability;

    public float UseTime { get; protected set; }

    public GameManager gameManager;

    public string useText { get; protected set; }


    public Item()
    {
        //this.gameManager = gameManager;
        useText = "Je suis un item lanbda.";
    }

    public virtual void use(Interactable interacibleItem)
    {
        /*if(interacibleItem.interactableName == InteracibleItem.DOOR)
        {
            Debug.Log("premier");
        }*/
        
    }
}
