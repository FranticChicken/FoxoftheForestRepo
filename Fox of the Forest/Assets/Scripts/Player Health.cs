using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    float maxHealth; 
    [HideInInspector]
    public float playerHealth;
    [HideInInspector]
    public bool gameOver;
    public Image healthBar; 

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 4f;
        playerHealth = maxHealth;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            gameOver = true;
        }

        healthBar.fillAmount = playerHealth / maxHealth;
    }
}
