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
        useText = "D�foncer au marteau";
        nameString = "une T�te r�duite";
    }

    public override void use(Interactable interacibleItem)
    {
        gameManager.LaunchTimerInteraction(this, interacibleItem);
    }
}
