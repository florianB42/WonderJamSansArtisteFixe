using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : Item
{
    public MatchItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.MATCH;
        durability = 1;
        UseTime = 0;
        useText = "Allumette";
        nameString = "une Allumette";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
