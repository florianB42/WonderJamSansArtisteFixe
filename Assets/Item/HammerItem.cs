using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerItem : Item
{
    public HammerItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.HAMMER;
        durability = 4;
        UseTime = 2;
        useText = "Défoncer au marteau";
        nameString = "un Marteau";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
