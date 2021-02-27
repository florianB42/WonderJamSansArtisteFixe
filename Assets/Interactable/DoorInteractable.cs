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

    public override void interact(List<Item> invetaire)
    {
        List<Item> usableItem = new List<Item>();
        usableItem.Add(new Item());
        popupSelectAction.GetComponent<PopupSelectAction>().showMenu(usableItem, this);
    }

    public void PassDoor()
    {
        //Debug.Log("Passe la porte");

        /*Demo*/
        interact(null);
    }

}
