using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKeyItem : Item
{
    public GoldKeyItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.GOLDKEY;
        durability = 1;
        UseTime = 1;
        useText = "Ouvrir";
        nameString = "une Clé en Or";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
