using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem : Item
{
    public HandItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.HAND;
        durability = 99;
        UseTime = 5;
        useText = "Crocheter";
        nameString = "des mains";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
