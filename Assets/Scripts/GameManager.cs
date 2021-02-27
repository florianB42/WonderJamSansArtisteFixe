using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Player player;
    public AIMonster Reaper;
    private static GameManager _instance;

    private float PlayerTimer;
    private float ReaperTimer;
    private static float Timer;
    private bool PlayerTurn; 
    private GameManager()
    {
        
    }

    public static GameManager Instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        Timer = 10;
        PlayerTimer = Timer;
        ReaperTimer = 0;
        PlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // possibilite de gerer les input ici
        if (PlayerTurn)
        {
            
            PlayerTimer -= Time.deltaTime;
            if (PlayerTimer < 0)
            {
                Debug.Log("Tour du joueur fini");
                player.GetComponentInChildren<PlayerController>().stopPlayer();
                Reaper.restartMonster();
                ReaperTimer = Timer;
                PlayerTurn = !PlayerTurn;
            }
        }
        else
        {
            ReaperTimer -= Time.deltaTime;
            if (ReaperTimer < 0)
            {
                Debug.Log("Tour du Reaper fini");
                player.GetComponentInChildren<PlayerController>().restartPlayer();
                Reaper.stopMonster();
                PlayerTimer = Timer;
                PlayerTurn = !PlayerTurn;
            }
        }
    }
}
