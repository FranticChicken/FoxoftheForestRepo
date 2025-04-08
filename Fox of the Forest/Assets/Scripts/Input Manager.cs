using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerController player;

    //dialogue stuff
    public DialogueManager dialogueScript;

    public EnemyController enemyCScript;
    public EnemyController enemyCScript2;
    public EnemyController enemyCScript3;
    public EnemyController enemyCScript4;

    public GameObject crouchNeutral;
    public GameObject crouchSad;
    public GameObject standNeutral;
    public GameObject standSad;

    bool isStanding;



    private void Start()
    {
        player = GetComponent<PlayerController>();
        standNeutral.SetActive(true);
        isStanding = true;
    }

    private void Update()
    {
        if (isStanding)
        {
            if (enemyCScript4.shouldBeSad == true || enemyCScript3.shouldBeSad == true || enemyCScript2.shouldBeSad == true || enemyCScript.shouldBeSad == true)
            {
                crouchSad.SetActive(false);
                crouchNeutral.SetActive(false);
                standNeutral.SetActive(false);
                standSad.SetActive(true);
            }
            else
            {
                crouchNeutral.SetActive(false);
                crouchSad.SetActive(false);
                standNeutral.SetActive(true);
                standSad.SetActive(false);

            }
        }
        
    }

    private void OnMove(InputValue moveValue)
    {
        Vector2 inputVector = moveValue.Get<Vector2>();
        if (dialogueScript.dialogueOver == true)
        {
            player.Move(inputVector);
        }
    }

    private void OnInteract(InputValue interactValue)
    {

        if (player.canInteractEB1 == true)
        {
            GameObject.FindGameObjectWithTag("Electrical Box").GetComponent<ElectricalBox>().health -= 1;
        }
        else if (player.canInteractEB2 == true)
        {
            GameObject.FindGameObjectWithTag("Electrical Box 2").GetComponent<ElectricalBox>().health -= 1;
        }
        else if (player.canInteractEB3 == true)
        {
            GameObject.FindGameObjectWithTag("Electrical Box 3").GetComponent<ElectricalBox>().health -= 1;
        }
        
    }

    private void OnJump(InputValue jumpValue)
    {
        if (dialogueScript.dialogueOver == true)
        {
            player.Jump();
        }
    }
    private void OnSprint(InputValue sprintValue)
    {
        if (sprintValue.isPressed && dialogueScript.dialogueOver == true)
        {
            player.Sprint();
        }
        else if (dialogueScript.dialogueOver == true)
        {
            player.Walk();
        }
    }
    private void OnCrouch(InputValue crouchValue)
    {
        if (crouchValue.isPressed && dialogueScript.dialogueOver == true)
        {
            player.Crouch();
            isStanding = false;
            if(enemyCScript.shouldBeSad == true || enemyCScript2.shouldBeSad == true || enemyCScript3.shouldBeSad == true || enemyCScript4.shouldBeSad == true)
            {
                crouchSad.SetActive(true);
                crouchNeutral.SetActive(false);
                standNeutral.SetActive(false);
                standSad.SetActive(false);
            }
            else
            {
                crouchNeutral.SetActive(true);
                crouchSad.SetActive(false);
                standNeutral.SetActive(false);
                standSad.SetActive(false);
                
            }
           

        }
        else if(dialogueScript.dialogueOver == true)
        {
            player.UnCrouch();
            isStanding = true;
            
        }
    }
}
