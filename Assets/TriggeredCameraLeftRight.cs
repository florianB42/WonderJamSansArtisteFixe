using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredCameraLeftRight : MonoBehaviour
{
    public Player player;
    public Camera cam;
    private float distanceEnter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            var distance = player.transform.position.x - this.transform.position.x;
            if (distance < 0 && distanceEnter > 0)
            {
                Debug.Log("Left");
                cam.GetComponentInChildren<CameraController>().MoveLeft();
            }
            else if (distance >= 0 && distanceEnter <= 0)
            {
                Debug.Log("Right");
                cam.GetComponentInChildren<CameraController>().MoveRight();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            distanceEnter = player.transform.position.x - this.transform.position.x;
        }
    }
}
