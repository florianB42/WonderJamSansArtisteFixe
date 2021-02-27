using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public GameObject popupSelectAction;

    private void Awake()
    {
        name = InteracibleItem.DOOR;
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
