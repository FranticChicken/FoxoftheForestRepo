using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject crouchSprite;

    private Rigidbody2D rb;
    private float xVelocity;
    private Vector2 moveVector = new Vector2(0, 0);
    private Vector2 targetVelocity = new Vector2(0, 0);
    private float currentSpeed;

    //interaction stuff
    [HideInInspector]
    public bool canInteractEB1;
    [HideInInspector]
    public bool canInteractEB2;
    [HideInInspector]
    public bool canInteractEB3;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
        canInteractEB1 = false;
        canInteractEB2 = false;
        canInteractEB3 = false;
    }

    private void Update()
    {
        targetVelocity = moveVector.normalized * currentSpeed;
        xVelocity = Mathf.Lerp(rb.velocity.x, targetVelocity.x, acceleration * Time.deltaTime);
        rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    }

    public void Move(Vector2 movement)
    {
        
        moveVector = movement;
        /*
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-0.1f, transform.localScale.z, transform.localScale.z);
        }
        else if(movement.x > 0)
        {
            transform.localScale = new Vector3(0.1f, transform.localScale.z, transform.localScale.z);
        }
        */
    }

    public void Sprint()
    {
        currentSpeed = sprintSpeed;
    }

    public void Walk()
    {
        currentSpeed = moveSpeed;
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

    }


    private bool IsGrounded()
    {
        bool grounded;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        grounded = hit.collider != null;

        return grounded;
    }

    public void Crouch()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        GetComponent<SpriteRenderer>().enabled = false;
        crouchSprite.SetActive(true);
        currentSpeed = crouchSpeed;
    }

    public void UnCrouch()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        GetComponent<SpriteRenderer>().enabled = true;
        crouchSprite.SetActive(false);
        currentSpeed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Electrical Box"))
        {
            canInteractEB1 = true;  
        }
        if (collision.CompareTag("Electrical Box 2"))
        {
            canInteractEB2 = true;
        }
        if (collision.CompareTag("Electrical Box 3"))
        {
            canInteractEB3 = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Electrical Box"))
        {
            canInteractEB1 = false;
        }
        if (collision.CompareTag("Electrical Box 2"))
        {
            canInteractEB2 = false;
        }
        if (collision.CompareTag("Electrical Box 3"))
        {
            canInteractEB1 = false;
        }
    }

    
}
