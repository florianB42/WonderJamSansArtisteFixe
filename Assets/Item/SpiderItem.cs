using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderItem : Item
{
    public SpiderItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.SPIDER;
        durability = 4;
        UseTime = 2;
        useText = "Défoncer au marteau";
        nameString = "une araignée";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
