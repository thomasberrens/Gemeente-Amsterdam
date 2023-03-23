using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ChoiceController))]
public class ChoiceControllerEditor : Editor
{
    private bool isCorrect;
    private string text = "";
    
    private bool showAddChoiceForm = false;

    public override void OnInspectorGUI()
    {
        // Draw the default serialized properties
        base.OnInspectorGUI();

        // Reference to the ChoiceController component
        ChoiceController choiceController = (ChoiceController)target;

        // Create a visually appealing section header
        GUILayout.Space(10);
        // Display the input fields for "isCorrect" and "text"

        showAddChoiceForm = EditorGUILayout.Foldout(showAddChoiceForm, "Add Choice");

        if (showAddChoiceForm)
        {
            isCorrect = EditorGUILayout.Toggle("Is Correct", isCorrect);
            text = EditorGUILayout.TextField("Text", text);

            // Add Choice button
            if (GUILayout.Button("Add Choice", GUILayout.Width(100)))
            {
                choiceController.AddChoice(isCorrect, text);
                isCorrect = false;
                text = "";
            }
        }
    }
}
