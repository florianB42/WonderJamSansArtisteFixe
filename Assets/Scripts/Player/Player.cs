using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Item> inventaire = new List<Item>();

    public float resistance;
    public static float maxResistance;
    void Start()
    {
        maxResistance = 100f;
        resistance = 100f;
    }

    void Update()
    {
        
    }
}
