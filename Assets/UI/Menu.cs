using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Commencer()
    {
        SceneManager.LoadScene("Manor", LoadSceneMode.Single);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void Aide()
    {
        SceneManager.LoadScene("Aide", LoadSceneMode.Single);
    }

    public void Objets()
    {
        SceneManager.LoadScene("Items", LoadSceneMode.Single);
    }
}
