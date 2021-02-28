using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : Item
{
    public MatchItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.MATCH;
        durability = 4;
        UseTime = 2;
        useText = "Allumer une allumette";
        nameString = "une allumette";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
