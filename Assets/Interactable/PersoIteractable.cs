using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoIteractable : Interactable
{
    public GameObject popupSelectAction;

    private void Awake()
    {
        interactableName = InteracibleItem.SELF;
        timeToOpen = 3;
        usableItem = new List<ItemType> { };
    }

    private void Start()
    {
        popupSelectAction.SetActive(false);
    }

    public override void valideOpenning()
    {

    }

    public override void interact(List<Item> inventaire)
    {
        maskCanUseThis = (uint)ItemType.MATCH + (uint)ItemType.TEDDY;
        List<Item> usable = new List<Item>();
        foreach (Item item in inventaire)
        {

            if ((maskCanUseThis & ((uint)item.name)) != 0)
            {
                usable.Add(item);
                maskCanUseThis -= (uint)item.name;
            }

        }
        popupSelectAction.GetComponent<PopupSelectAction>().showMenu(usable, this);
        
    }
}
