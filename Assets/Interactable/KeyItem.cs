using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{

    public KeyItem()
    {
        interactionList = new List<InteracibleItem>();
        name = ItemType.KEY;
        durability = 1;
        UseTime = 0.5f;
        useText = "utiliser une clé";

        interactionList = new List<InteracibleItem> {
            InteracibleItem.CHEST, InteracibleItem.DOOR };
    }

    public override void use(Interactable interacibleItem)
    {
        if (interacibleItem.GetType() == typeof(ChestInteractable))
        {
            
        }
    }
}
