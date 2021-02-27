using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    KEY, GOLDKEY, CROWBAR, HAMMER
}

public class Item
{
    public ItemType name { get; protected set; }

    //list des objets avec lesquels cet item peut interagir
    protected List<InteracibleItem> interactionList;

    protected int durability;

    protected float UseTime;

    public string useText { get; protected set; }


    public Item()
    {
        useText = "Je suis un item lanbda.";
    }

    public virtual void use(Interactable interacibleItem)
    {
        if(interacibleItem.GetType() == typeof(DoorInteractable))
        {
            Debug.Log("premier");
        }
    }
}
