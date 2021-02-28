using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashlightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    public void RotateFlashlight(float x, float y)
    {
        if(x == 0 && y == 0)
        {
            return;
        }

        float rotation = 0f;

        if (y == 0)
        {
            rotation = x * -90f;
        }
        else if (y > 0)
        {
            rotation = x * -45f;
        }
        else if (y < 0)
        {
            if (x == 0)
            {
                rotation = 180f;
            }
            else
            {
                rotation = x * -135f;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
