using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceController : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup choiceGroup;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private UnityEvent<InteractableChoice> onChoiceSelected;
    [SerializeField] private Button replayButton;
    /// <summary>
    /// Initializes and displays the list of interactable choices by instantiating them as UI elements. Also adds a listener to each choice object that invokes the onChoiceSelected event.
    /// </summary>
    /// <param name="choices">A list of InteractableChoice objects to be displayed.</param>
    public void InitializeChoices(List<InteractableChoice> choices)
    {
        replayButton.gameObject.SetActive(true);
        choices.ForEach(choice =>
        {
            GameObject choiceObject = Instantiate(choicePrefab, choiceGroup.transform);
            choiceObject.GetComponentInChildren<TMP_Text>().text = choice.ChoiceText;

            choiceObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                onChoiceSelected?.Invoke(choice);
            });
        });
    }
    
    

    /// <summary>
    /// Disables the choice UI elements by destroying all instantiated choice objects.
    /// </summary>
    public void Disable()
    {
        replayButton.gameObject.SetActive(false);
        foreach (Transform child in choiceGroup.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
