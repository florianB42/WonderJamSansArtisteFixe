using UnityEngine;
using System.Collections.Generic;

public enum InteracibleItem
{
    NOTHING, CHEST, DOOR
}
public class Interactable : MonoBehaviour
{
    protected InteracibleItem name;
    public bool alreadyOpen  {get; protected set;}

    private void Start()
    {
        alreadyOpen = false;
    }

    public virtual void interact(List<Item> invetaire) 
    {
        //popupSelectAction.GetComponent<PopupSelectAction>().showMenu(new List<Item>(), InteracibleItem.none);
        Debug.Log("Activé");
    }
}
