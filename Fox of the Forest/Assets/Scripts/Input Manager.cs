using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerController player;

    //dialogue stuff
    public DialogueManager dialogueScript;
    

    private void Start()
    {
        player = GetComponent<PlayerController>();
        
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
        }
        else if(dialogueScript.dialogueOver == true)
        {
            player.UnCrouch();
        }
    }
}
