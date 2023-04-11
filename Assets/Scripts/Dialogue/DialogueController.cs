using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [field: SerializeField] public TMP_Text DialogueTextField { get; private set; }
    [field: SerializeField] public GameObject DialoguePanel { get; private set; }
    [field: SerializeField] public float TypingSpeed { get; private set; } = 0.05f;
    [field: SerializeField] public float LineDelay { get; private set; } = 0.1f;
    [field: SerializeField] public UnityEvent OnDialogueStart { get; private set; }
    [field: SerializeField] public UnityEvent OnDialogueEnd { get; private set; }


    private int currentLine = 0;
    private bool isTyping = false;

    public void StartDialogue(string dialogueText)
    {
        DialogueTextField.text = "";
        StartCoroutine(ShowDialogue(dialogueText));
    }

    public void Disable()
    {
        DialogueTextField.text = "";
        DialoguePanel.SetActive(false);
    }

    private IEnumerator ShowDialogue(string dialogueText)
    {
        OnDialogueStart?.Invoke();
        
        DialoguePanel.SetActive(true);
        DialogueTextField.gameObject.SetActive(true);

        yield return TypeText(dialogueText);

        OnDialogueEnd?.Invoke();
    }

    private IEnumerator TypeText(string textToType)
    {
        isTyping = true;

        for (int i = 0; i < textToType.Length; i++)
        {
            DialogueTextField.text += textToType[i];
            yield return new WaitForSeconds(TypingSpeed);
        }

        DialogueTextField.text += " ";

        isTyping = false;
    }
}