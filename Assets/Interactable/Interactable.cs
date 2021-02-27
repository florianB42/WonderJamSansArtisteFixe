using UnityEngine;
using System.Collections.Generic;

public enum InteracibleItem
{
    NOTHING, CHEST, DOOR
}
public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    public Vector3 relativePosision = new Vector3(0, 0, 0);
    protected InteracibleItem name;

    private void Start()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + relativePosision, radius);

    }

    public virtual void interact(List<Item> invetaire) 
    {
        //popupSelectAction.GetComponent<PopupSelectAction>().showMenu(new List<Item>(), InteracibleItem.none);
        Debug.Log("Activé");
    }
}
