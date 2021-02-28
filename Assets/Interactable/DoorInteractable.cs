using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public GameObject popupSelectAction;

    private void Awake()
    {
        interactableName = InteracibleItem.DOOR;
        timeToOpen = 3;
        usableItem = new List<ItemType> { ItemType.KEY, ItemType.HAMMER };
    }

    private void Start()
    {
        popupSelectAction.SetActive(false);
    }

    public override void valideOpenning()
    {
        Debug.Log("Valide Opening Door");
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    } 

    public override void interact(List<Item> inventaire)
    {
        if (!alreadyOpen)
        {
            maskCanUseThis = (uint)ItemType.KEY + (uint)ItemType.HAMMER;
            alreadyOpen = true;
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

}
