using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Image dialogueBackground;

    public string[] sentences;
    public float textSpeed;

    private int index;

    [HideInInspector]
    public bool dialogueOver;

    //controls
    public InputActionReference Click;
    public InputActionReference Tab;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        dialogueOver = false;
        dialogueText.text = string.Empty;
        StartDialogue();

        Click.action.performed += Skip;
        Tab.action.performed += Skip2;
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        // type each character 1 by 1
        foreach (char c in sentences[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBackground.gameObject.SetActive(false);
            dialogueOver = true;
        }
    }

    void Skip(InputAction.CallbackContext context)
    {
        if (dialogueText.text == sentences[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = sentences[index];
        }
    }

    void Skip2(InputAction.CallbackContext context)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            dialogueBackground.gameObject.SetActive(false);

            dialogueOver = true;
        }
    }

    void Update()
    {



    }
}
