using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWinningDoor : MonoBehaviour
{
    public Player player;
    public Camera cam;
    private float distanceEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene("Victoire", LoadSceneMode.Single);
            Debug.Log("Victoire!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

}
