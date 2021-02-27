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
        UseTime = 0;

        interactionList = new List<InteracibleItem> {
            InteracibleItem.CHEST, InteracibleItem.DOOR };
    }
}
