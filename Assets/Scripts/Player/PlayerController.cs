using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector3 change;
    private Animator animator;
    public Player player;

    private bool StopPlayer;
    private bool canInteracte;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StopPlayer = false;
        canInteracte = true;
    }

    public void FixedUpdate()
    {
        if (!StopPlayer)
        {
            Vector3 oldChange = change;
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            //Collider2D result = Physics2D.OverlapCircle(transform.position, 1.5f, 0, 21);

            UpdateAnimationAndMove();

            if((oldChange.x != change.x) || (oldChange.y != change.y))
            {
                UpdateFlashlight();
            }
        }
    }

    public void Update()
    {
        if (canInteracte)
        {
            if (!StopPlayer && Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit2D col = Physics2D.CircleCast(transform.position, 0.75f, new Vector2(0, 0), 1, LayerMask.GetMask("Interactable"));
                if (col.collider != null)
                {
                    canInteracte = false;
                    col.collider.gameObject.GetComponent<Interactable>().interact(player.inventaire);
                }
            }
            else if (!StopPlayer && Input.GetKeyDown(KeyCode.Space))
            {
                canInteracte = false;
                gameObject.GetComponent<PersoIteractable>().interact(player.inventaire);
            }
        }
    }

    public void resetInteraction()
    {
        Debug.Log("Reset Interaction");
        canInteracte = true;
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

    void UpdateFlashlight()
    {
        GetComponentInChildren<FlashlightController>().RotateFlashlight(change.x, change.y);
    }

    public void stopPlayer()
    {
        StopPlayer = true;
        animator.SetBool("moving", false);
    }

    public void restartPlayer()
    {
        StopPlayer = false;
    }
}
