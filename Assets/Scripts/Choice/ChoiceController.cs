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

    public void InitializeChoices(List<InteractableChoice> choices)
    {
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

    public void Disable()
    {
        foreach (Transform child in choiceGroup.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
