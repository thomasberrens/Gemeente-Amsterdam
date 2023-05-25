using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Represents an interactable choice in the game.
/// </summary>
[CreateAssetMenu(fileName = "New Interactable Scenario", menuName = "Interactable Scenario")]
public class InteractableScenario : ScriptableObject {
    
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string DialogueText { get; private set; }
    [field: SerializeField] public string PrefabDirectory { get; private set; }
    
    [field: SerializeField] public VideoClip CutScene { get; private set; }
    
    [field: SerializeField] public List<InteractableChoice> Choices { get; private set; }
}
