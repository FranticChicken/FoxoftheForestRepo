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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
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
}
