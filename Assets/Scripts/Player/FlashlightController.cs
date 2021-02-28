using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashlightController : MonoBehaviour
{
    public bool isLightOn;
    public Light2D flashlight;
    private float time = 0f;

    private void Start()
    {
        isLightOn = true;
    }

    private void Update()
    {
        if (flashlight != null)
        {
            if (isLightOn == true)
            {
                StartCoroutine(TurnLightsOff());
            }
            if (isLightOn == false)
            {
                StartCoroutine(TurnLightsOn());
            }
        }
    }

    IEnumerator TurnLightsOff()
    {
        yield return new WaitForSeconds(Random.Range(0.005f, 8f));
        if (Time.time > time)
        {
            time = Time.time + Random.Range(0.005f, 8f);
            LightsOff();
        }
    }

    void LightsOff()
    {
        flashlight.enabled = false;
        isLightOn = false;
    }

    IEnumerator TurnLightsOn()
    {
        yield return new WaitForSeconds(Random.Range(0.005f, 0.2f));
        LightsOn();
    }

    void LightsOn()
    {
        flashlight.enabled = true;
        isLightOn = true;
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