using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    public GameObject popupInfo;
    public GameObject popupChoix;

    private bool hasKey;
    private bool hasHammer;

    private void Awake()
    {
        interactableName = InteracibleItem.CHEST;
        timeToOpen = 3;
        usableItem = new List<ItemType> { ItemType.KEY, ItemType.CROWBAR};
        
    }

    void Start()
    {
        popupInfo.SetActive(false);
        popupChoix.SetActive(false);
        hasHammer = false;
        hasKey = false;
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
            maskCanUseThis = (uint)ItemType.KEY + (uint)ItemType.CROWBAR;
            alreadyOpen = true;
            List<Item> usable = new List<Item>();
            foreach (Item item in inventaire)
            {
                if (usableItem.Contains(item.name))
                {
                    if ((maskCanUseThis & ((uint)item.name)) != 0)
                    {
                        usable.Add(item);
                        maskCanUseThis -= (uint)item.name;
                    }

                }
                    
            }
            popupChoix.GetComponent<PopupSelectAction>().showMenu(usable, this);
        }
    }
}
