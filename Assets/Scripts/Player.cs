using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Item> inventaire;

    public float resistance;

    void Start()
    {
        inventaire = new List<Item>();
        resistance = 0.5f;
    }

    void Update()
    {
        
    }
}
