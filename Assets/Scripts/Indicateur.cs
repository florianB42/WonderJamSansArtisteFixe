using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicateur : MonoBehaviour
{
    public Transform target;

    public GameObject indicator;

    Renderer rd;

    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rd.isVisible)
        {
            if(!indicator.activeSelf)
            {
                indicator.SetActive(true);
            }

            Vector2 direction = target.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 10f, LayerMask.GetMask("CamCollider"));

            if(ray.collider != null)
            {
                Debug.Log("Cam Collider detected");
                indicator.transform.position = ray.point;
            }
        }
        else
        {
            if (indicator.activeSelf)
            {
                indicator.SetActive(false);
            }
        }
    }
}
