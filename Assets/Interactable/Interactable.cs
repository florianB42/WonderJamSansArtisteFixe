using UnityEngine;
using System.Collections.Generic;

public enum InteracibleItem : uint
{
    NOTHING, CHEST, DOOR, SELF, EXIT_DOOR
}
public class Interactable : MonoBehaviour
{
    public InteracibleItem interactableName { get; protected set; }
    public bool alreadyOpen  {get; protected set;}

    //liste d'Items utilisable sur la cette objet
    public List<ItemType> usableItem { get; protected set; }

    public float timeToOpen{ get; protected set; }


    protected uint maskCanUseThis = 0;

    private void Start()
    {
        alreadyOpen = false;
    }

    public virtual void interact(List<Item> inventaire) 
    {
        //popupSelectAction.GetComponent<PopupSelectAction>().showMenu(new List<Item>(), InteracibleItem.none);
        Debug.Log("Activé");
    }

    public virtual void valideOpenning()
    { 

    }

    public virtual void cancelInteract()
    {
        alreadyOpen = false;
    }
}
