using UnityEngine;
using System.Collections.Generic;

public enum InteracibleItem
{
    NOTHING, CHEST, DOOR
}
public class Interactable : MonoBehaviour
{
    public InteracibleItem interactableName { get; protected set; }
    public bool alreadyOpen  {get; protected set;}

    //liste d'Items utilisable sur la cette objet
    public List<ItemType> usableItem { get; protected set; }

    public float timeToOpen{ get; protected set; }

    private void Start()
    {
        alreadyOpen = false;
    }

    public virtual void interact(List<Item> invetaire) 
    {
        //popupSelectAction.GetComponent<PopupSelectAction>().showMenu(new List<Item>(), InteracibleItem.none);
        Debug.Log("Activ�");
    }
}
