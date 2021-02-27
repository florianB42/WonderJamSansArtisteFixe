using UnityEngine;
using System.Collections.Generic;

public enum InteracibleItem
{
    NOTHING, CHEST, DOOR
}
public class Interactable : MonoBehaviour
{
    protected InteracibleItem name;

    private void Start()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        

    }

    public virtual void interact(List<Item> invetaire) 
    {
        //popupSelectAction.GetComponent<PopupSelectAction>().showMenu(new List<Item>(), InteracibleItem.none);
        Debug.Log("Activé");
    }
}
