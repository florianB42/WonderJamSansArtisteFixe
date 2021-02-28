using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    public GameObject popupChoix;

    private void Awake()
    {
        interactableName = InteracibleItem.CHEST;
        timeToOpen = 3;
        usableItem = new List<ItemType> { ItemType.KEY, ItemType.CROWBAR};
        
    }

    void Start()
    {
        popupChoix.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void valideOpenning()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    public override void interact(List<Item> inventaire)
    {
        if (!alreadyOpen)
        {
            maskCanUseThis = (uint)ItemType.KEY + (uint)ItemType.CROWBAR + (uint)ItemType.HAND;
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
            popupChoix.GetComponent<PopupSelectAction>().showMenu(usable, this);
        }
    }
}
