using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    KEY, GOLDKEY, CROWBAR, HAMMER
}

public class Item
{
    protected ItemType name;

    //list des objets avec lesquels cet item peut interagir
    protected List<InteracibleItem> interactionList;

    protected int durability;

    protected float UseTime;

    public string useText { get; private set; }


    public Item()
    {
        useText = "Je suis un item lanbda.";
    }

    public void use(Interactable interacibleItem)
    {
        if(interacibleItem.GetType() == typeof(DoorInteractable))
        {
            Debug.Log("premier");
        }
    }
}
