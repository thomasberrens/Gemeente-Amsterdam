using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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

    /// <summary>
    /// Starts the dialogue by initializing the text field and displaying the dialogue text one character at a time.
    /// </summary>
    /// <param name="dialogueText">The dialogue text to display.</param>
    public void StartDialogue(string dialogueText)
    {
        DialogueTextField.text = "";
        StartCoroutine(ShowDialogue(dialogueText));
    }

    /// <summary>
    /// Disables the dialogue by clearing the text field and hiding the dialogue panel.
    /// </summary>
    public void Disable()
    {
        DialogueTextField.text = "";
        DialoguePanel.SetActive(false);
    }

    /// <summary>
    /// Coroutine that shows the dialogue text in the panel and invokes OnDialogueStart and OnDialogueEnd events.
    /// </summary>
    /// <param name="dialogueText">The dialogue text to display.</param>
    /// <returns>An IEnumerator for the coroutine.</returns>
    private IEnumerator ShowDialogue(string dialogueText)
    {
        OnDialogueStart?.Invoke();
        
        DialoguePanel.SetActive(true);
        DialogueTextField.gameObject.SetActive(true);

        yield return TypeText(dialogueText);

        OnDialogueEnd?.Invoke();
    }

    /// <summary>
    /// Coroutine that types the text one character at a time with a delay determined by TypingSpeed.
    /// </summary>
    /// <param name="textToType">The text to type in the dialogue text field.</param>
    /// <returns>An IEnumerator for the coroutine.</returns>
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