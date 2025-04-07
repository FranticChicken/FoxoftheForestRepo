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
