using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetourM()
    {
        Debug.Log("Coucou");
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
