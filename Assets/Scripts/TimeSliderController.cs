using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSliderController : MonoBehaviour
{
    public Slider slider;
    public float maxValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("TimeBar").GetComponent<Slider>();
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0)
        {
            slider.value -= Time.deltaTime;
        }
    }

    public void ResetValue()
    {
        slider.value = maxValue;
    }

    public void SetMaxValue(float value)
    {
        maxValue = value;
        slider.maxValue = value;
        slider.value = value;
    }
}
