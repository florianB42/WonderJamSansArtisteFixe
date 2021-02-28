using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyItem : Item
{
    public TeddyItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.TEDDY;
        durability = 1;
        UseTime = 3;
        useText = "Ourson";
        nameString = "un Ourson";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}

