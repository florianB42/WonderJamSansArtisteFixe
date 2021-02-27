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
        usableItem = new List<ItemType> { ItemType.KEY, ItemType.CROWBAR, ItemType.HAMMER };
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

    public override void interact(List<Item> inventaire)
    {
        if (!alreadyOpen)
        {
            alreadyOpen = true;
            List<Item> usable = new List<Item>();
            foreach (Item item in inventaire)
            {
                if (usableItem.Contains(item.name))
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
                                          
                }
                    
            }
            popupChoix.GetComponent<PopupSelectAction>().showMenu(usable, this);
        }
    }
}
