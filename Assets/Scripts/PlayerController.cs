using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector3 change;
    private Animator animator;
    public Player player;

    private bool StopPlayer;
    private bool canInteract;

    private Interactable objectToInteract;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StopPlayer = false;
        canInteract = false;
    }

    public void FixedUpdate()
    {
        if (!StopPlayer)
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            //Collider2D result = Physics2D.OverlapCircle(transform.position, 1.5f, 0, 21);
            if (canInteract && Input.GetKeyDown(KeyCode.E))
            {
                objectToInteract.interact(player.inventaire);
            }
                


            UpdateAnimationAndMove();
        }
    }

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detecté");
        if (collision.gameObject.layer == 21)
        {
            Debug.Log("interactable Detecté");
            objectToInteract = collision.gameObject.GetComponent<Interactable>();
        }
    }

    public void stopPlayer()
    {
        StopPlayer = true;
    }

    public void restartPlayer()
    {
        StopPlayer = false;
    }
}
