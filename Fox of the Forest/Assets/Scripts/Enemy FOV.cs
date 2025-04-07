using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [HideInInspector]
    public bool followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("follow player = true");
            followPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
