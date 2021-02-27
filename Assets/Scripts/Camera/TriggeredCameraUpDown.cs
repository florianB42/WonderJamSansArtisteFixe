using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredCameraUpDown : MonoBehaviour
{

    public Player player;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            var distance = player.transform.position.y - this.transform.position.y;
            if (distance < 0)
            {
                Debug.Log("UP");
                cam.GetComponentInChildren<CameraController>().MoveUp();
            }
            else
            {
                Debug.Log("Down");
                cam.GetComponentInChildren<CameraController>().MoveDown();
            }
        }
    }
}
