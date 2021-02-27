using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    public float CameraHeight;
    public float CameraWidth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
           
    }

    private void MoveUp()
    {
        transform.LookAt(transform.position + Vector3.up * CameraHeight);
    }

    private void MoveDown()
    {
        transform.LookAt(transform.position + Vector3.up * (-CameraHeight));
    }

    private void MoveLeft()
    {
        transform.LookAt(transform.position + Vector3.up * (-CameraWidth));
    }

    private void MoveRight()
    {
        transform.LookAt(transform.position + Vector3.up * CameraWidth);
    }
}
