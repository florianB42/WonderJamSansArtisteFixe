using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class ResistanceComponent : MonoBehaviour
{

    public SliderController sliderResistance;
    public Light2D playerLight;
    public Player player;


    float lightOuterRadius;
    float lightInnerRadius;
    float lightIntensity;
    float lightInnerAngle;
    float lightOuterAngle;
    // Start is called before the first frame update
    void Start()
    {
        lightInnerRadius = playerLight.pointLightInnerRadius;
        lightOuterRadius = playerLight.pointLightOuterRadius;
        lightIntensity = playerLight.intensity;
        lightInnerAngle = playerLight.pointLightInnerAngle;
        lightOuterAngle = playerLight.pointLightOuterAngle;
    }

    // Update is called once per frame
    void Update()
    {
        //playerLight.pointLightInnerRadius = lightInnerRadius * player.resistance / Player.maxResistance;
        playerLight.pointLightOuterRadius = lightOuterRadius * player.resistance / Player.maxResistance;
        playerLight.intensity = lightIntensity * player.resistance / Player.maxResistance;
        //playerLight.pointLightInnerAngle = InnerAngle * player.resistance / Player.maxResistance;
        //playerLight.pointLightOuterAngle = lightOuterAngle * player.resistance / Player.maxResistance;
    }

    public void MinusResistance(float minus)
    {
        player.resistance -= minus;
        if ( player.resistance < 0)
        {
            player.resistance = 0;
        }
        sliderResistance.SetValue(player.resistance);
    }

    public void PlusResistance(float plus)
    {
        player.resistance += plus;
        if (player.resistance > Player.maxResistance)
        {
            player.resistance = Player.maxResistance;
        }
        sliderResistance.SetValue(player.resistance);
    }

}
