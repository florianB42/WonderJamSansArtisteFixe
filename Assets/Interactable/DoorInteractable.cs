using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public GameObject popupSelectAction;
    private uint maskCanUseThis = uint.MaxValue - (uint) ItemType.KEY.GetHashCode() - (uint) ItemType.HAMMER.GetHashCode();

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

    public override void interact(List<Item> inventaire)
    {
        if (!alreadyOpen)
        {
            alreadyOpen = true;
            List<Item> usable = new List<Item>();
            foreach (Item item in inventaire)
            {
                if ((maskCanUseThis & (uint)item.GetType().GetHashCode()) != 0)
                {
                    usable.Add(item);
                    maskCanUseThis += (uint)item.GetType().GetHashCode();
                }
                /*if (usableItem.Contains(item.name))
                {
                    if (item.name == ItemType.KEY && !hasKey)
                    {
                        usable.Add(item);
                        hasKey = true;
                    }

                    if (item.name == ItemType.HAMMER && !hasHammer)
                    {
                        usable.Add(item);
                        hasHammer = true;
                    }

                }*/

            }
            popupSelectAction.GetComponent<PopupSelectAction>().showMenu(usable, this);
        }
    }

}
