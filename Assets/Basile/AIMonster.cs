using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMonster : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.destination = player.position;
       // transform.LookAt(playerTransform);
    }

    public void stopEnnemy()
    {
        agent.destination = transform.position;
    }

    public void EnnemyFollowing()
    {
        agent.destination = player.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.layer == 20)
        {
            animator.SetBool("PlayerInRange", true);
            //TODO appel de la fonction GameOver et mort du joueur
        }
    }
}
