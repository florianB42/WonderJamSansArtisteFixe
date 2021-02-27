using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retour()
    {
        Debug.Log("Coucou");
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
    
}
