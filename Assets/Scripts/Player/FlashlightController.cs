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
        if (isLightOn == true)
        {
            StartCoroutine(TurnLightsOff());
        }
        if (isLightOn == false)
        {
            StartCoroutine(TurnLightsOn());
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
}
