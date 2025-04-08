using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalBox : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        health = 3; 
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            playerControllerScript.electricBoxesTampered += 1;
            Destroy(gameObject);
        }
    }
}
