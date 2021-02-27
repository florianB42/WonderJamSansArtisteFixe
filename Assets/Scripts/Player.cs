using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Item> inventaire;
    void Start()
    {
        inventaire = new List<Item>();
        inventaire.Add(new KeyItem());
        inventaire.Add(new KeyItem());
        inventaire.Add(new KeyItem());
        inventaire.Add(new KeyItem());
        inventaire.Add(new KeyItem());
        inventaire.Add(new HammerItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
