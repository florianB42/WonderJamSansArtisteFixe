using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Start is called before the first frame update
    public string useText { get; private set; }
    public Item()
    {
        useText = "Je suis un item lanbda.";
    }


    public void use(Interactable interacibleItem)
    {
        if(interacibleItem.GetType() == typeof(DoorInteractable))
        {
            Debug.Log("premier");
        }
    }
}
