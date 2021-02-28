using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{

    public KeyItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.KEY;
        durability = 1;
        UseTime = 0.5f;
        useText = "Déverouiller";
        nameString = "une Clé";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
