using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera cam;
    private bool haveBeentriggered;
    private float timerTrigger;
    private static float newTrigger;
    // Start is called before the first frame update
    void Start()
    {
        haveBeentriggered = false;
        timerTrigger = 0;
        newTrigger = 2;
    }

    private void Update()
    {
        if (haveBeentriggered)
        {
            timerTrigger += Time.deltaTime;
            if (timerTrigger > newTrigger)
            {
                haveBeentriggered = false;
                timerTrigger = 0;
            }
        }
    }

    public void MoveUp()
    {
        if (!haveBeentriggered)
        {
            cam.transform.Translate(Vector3.up * 9);
            haveBeentriggered = true;
        }
    }

    public void MoveDown()
    {
        if (!haveBeentriggered)
        {
            cam.transform.Translate(Vector3.down * 9);
            haveBeentriggered = true;
        }
    }

    public void MoveLeft()
    {
        if (!haveBeentriggered)
        {
            cam.transform.Translate(Vector3.left * 16);
            haveBeentriggered = true;
        }
    }

    public void MoveRight()
    {
        if (!haveBeentriggered)
        {
            cam.transform.Translate(Vector3.right * 16);
            haveBeentriggered = true;
        }
    }
}
