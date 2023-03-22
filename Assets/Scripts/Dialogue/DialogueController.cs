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
    [field: SerializeField] public string[] DialogueInput { get; private set; }
    [field: SerializeField] public float TypingSpeed { get; private set; } = 0.05f;
    [field: SerializeField] public float LineDelay { get; private set; } = 0.1f;
    [field: SerializeField] public UnityEvent OnDialogueStart { get; private set; }
    [field: SerializeField] public UnityEvent OnDialogueEnd { get; private set; }

    private int currentLine = 0;
    private bool isTyping = false;

    private void Start()
    {
        DialogueTextField.text = "";
        StartCoroutine(ShowDialogue());
    }

    private IEnumerator ShowDialogue()
    {
        OnDialogueStart?.Invoke();
        while (currentLine < DialogueInput.Length)
        {
            yield return StartCoroutine(TypeText(DialogueInput[currentLine]));
            currentLine++;
            yield return new WaitForSeconds(LineDelay);
        }

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