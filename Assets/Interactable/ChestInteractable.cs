using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    public GameObject popupInfo;
    public GameObject popupChoix;
    private void Awake()
    {
        name = InteracibleItem.CHEST;
    }

    void Start()
    {
        popupInfo.SetActive(false);
        popupChoix.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact(List<Item> invetaire)
    {
        if (!alreadyOpen)
        {
            alreadyOpen = true;
            List<Item> usable = new List<Item>();
            foreach (Item item in invetaire)
            {
                if (item.name == ItemType.KEY)
                    usable.Add(item);
                if (item.name == ItemType.CROWBAR)
                    usable.Add(item);
            }
            popupChoix.GetComponent<PopupSelectAction>().showMenu(usable, this);
        }
    }
}
