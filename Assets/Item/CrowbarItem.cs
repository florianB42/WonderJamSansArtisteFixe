using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarItem : Item
{
    public CrowbarItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.CROWBAR;
        durability = 4;
        UseTime = 2;
        useText = "Défoncer au marteau";
        nameString = "un Pied-de-Biche";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
