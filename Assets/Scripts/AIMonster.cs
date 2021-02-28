using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIMonster : MonoBehaviour
{
    public Transform player;
    private int X;
    private NavMeshAgent agent;
    private Animator animator;
    private bool StopMonster;
    private int turns = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        StopMonster = true;
    }

    public void FixedUpdate()
    {

        if (!StopMonster)
        {
            agent.destination = player.position;
            
        }
        int oldX = X;
        float diffX = transform.position.x - player.position.x;
        X = (diffX > 0 ? -1 : (diffX < 0 ? 1 : 0));

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
     
        animator.SetFloat("moveX", X);
        
    }

    public void stopMonster()
    {
        StopMonster = true;
        animator.SetBool("moving", false);
        agent.destination = transform.position;
    }

    public void restartMonster()
    {
        StopMonster = false;
        animator.SetBool("moving", true);
        turns++;
        if (turns >= 5)
        {
            GetComponent<NavMeshAgent>().speed *= (float)1.1;
            Debug.Log(GetComponent<NavMeshAgent>().speed);
        }
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
            agent.destination = transform.position;
            animator.SetBool("PlayerInRange", true);
            //TODO appel de la fonction GameOver et mort du joueur
            StartCoroutine(UserDie());
        }
    }

    IEnumerator UserDie()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
