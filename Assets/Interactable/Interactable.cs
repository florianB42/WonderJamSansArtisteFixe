using UnityEngine;
using System.Collections.Generic;

public enum InteracibleItem
{
    none,
    Coffre,
    porte,
}
public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Vector3 relativePosision = new Vector3(0, 0, 0);

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

    }
}
