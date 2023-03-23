using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class ChoiceController : MonoBehaviour
{
    [field: SerializeField] public VerticalLayoutGroup OptionGroup { get; private set; } 
    [field: SerializeField] public Choice OptionPrefab { get; private set; }
    [field: SerializeField] public List<Choice> Choices { get; private set; }
    public void AddChoice(bool isCorrect, string text)
    {
        if (Choices == null) Choices = new List<Choice>();
        
        Choice option = Instantiate(OptionPrefab, OptionGroup.transform);
        
        option.IsCorrect = isCorrect;
        option.Text = text;

        Choices.Add(option);
        option.GetComponentInChildren<TMP_Text>().text = option.Text;
    }
}
