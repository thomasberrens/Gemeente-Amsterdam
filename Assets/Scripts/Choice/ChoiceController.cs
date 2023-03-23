using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class ChoiceController : MonoBehaviour
{
    [field: SerializeField] public VerticalLayoutGroup OptionGroup { get; private set; } 
    [field: SerializeField] public GameObject OptionPrefab { get; private set; }
    [field: SerializeField] public List<Choice> Choices { get; private set; }

    public void AddChoice(Choice choice)
    {
        if (Choices == null) Choices = new List<Choice>();

        Choices.Add(choice);

        GameObject option = Instantiate(OptionPrefab, OptionGroup.transform);

        option.GetComponentInChildren<TMP_Text>().text = choice.Text;
    }
}
