using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform patrolPt1;
    Transform patrolPt2;
    public float speed = 2;
    Transform targetPoint;
    Transform sprites;
    EnemyFOV fOVScript;
    public Transform player;
    [SerializeField] private LayerMask groundLayer;
    float offset = 57;

    // Start is called before the first frame update
    void Start()
    {
        patrolPt1 = transform.Find("PatrolPt1").GetComponent<Transform>();
        patrolPt2 = transform.Find("PatrolPt2").GetComponent<Transform>();
        targetPoint = patrolPt1;
        sprites = transform.Find("Sprites").GetComponent<Transform>();
        fOVScript = sprites.transform.Find("FOV").GetComponent<EnemyFOV>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hello");
        }
    }

    void FlipTowards(Vector2 targetPosition)
    {
        Vector3 scale = sprites.transform.localScale;
        scale.x = (targetPosition.x < sprites.transform.position.x) ? -1 : 1;
        sprites.transform.localScale = scale;
    }

    private bool IsGrounded()
    {
        bool grounded;
        RaycastHit2D hit = Physics2D.Raycast(sprites.transform.position, Vector2.down, 2f, groundLayer);
        grounded = hit.collider != null;

        return grounded;
    }

    // Update is called once per frame
    void Update()
    {
        if (fOVScript.followPlayer == true && IsGrounded())
        {
            // Move towards the target point
            Vector2 currentPos = sprites.transform.position;
            Vector2 targetPos = new Vector3(player.position.x, currentPos.y); // lock Y

            sprites.transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

            // Optional: Flip enemy to face movement direction
            FlipTowards(player.position);
        }
        else
        {
            // Move towards the target point
            sprites.transform.position = Vector2.MoveTowards(sprites.transform.position, targetPoint.position, speed * Time.deltaTime);

            // If close enough to the target point, switch to the other
            if (Vector2.Distance(sprites.transform.position, targetPoint.position) < 0.1f)
            {
                targetPoint = (targetPoint == patrolPt2) ? patrolPt1 : patrolPt2;
            }

            // Optional: Flip enemy to face movement direction
            FlipTowards(targetPoint.position);
        }
        
        Debug.Log(IsGrounded());

    }
}
