using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMonster : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    private bool StopMonster;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        StopMonster = true;
    }

    void Update()
    {
        if (!StopMonster)
        {
            agent.destination = player.position;
        }
       // transform.LookAt(playerTransform);
    }

    public void stopMonster()
    {
        StopMonster = true;
    }

    public void restartMonster()
    {
        StopMonster = false;
    }

    public void EnnemyFollowing()
    {
        agent.destination = player.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.layer == 20)
        {
            animator.SetBool("PlayerInRange", true);
            //TODO appel de la fonction GameOver et mort du joueur
        }
    }
}
