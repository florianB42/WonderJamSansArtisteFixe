using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerItem : Item
{
    public HammerItem()
    {
        name = ItemType.HAMMER;
        durability = 4;
        UseTime = 2;

        interactionList = new List<InteracibleItem> { 
            InteracibleItem.DOOR };
     

    }

}
