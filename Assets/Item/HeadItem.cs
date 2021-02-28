using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadItem : Item
{

    public HeadItem(GameManager gameManager)
    {
        this.gameManager = gameManager;
        name = ItemType.HEAD;
        durability = 4;
        UseTime = 2;
        useText = "Défoncer au marteau";
        nameString = "une Tête réduite";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
