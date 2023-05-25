using UnityEngine;

/// <summary>
/// Represents an interactable choice in the game.
/// </summary>
[CreateAssetMenu(fileName = "New Interactable Choice", menuName = "Interactable Choice")]
public class InteractableChoice : ScriptableObject
{
    /// <summary>
    /// Gets or sets the text for the interactable choice.
    /// </summary>
    [field: SerializeField] [JsonField("choice")]
    public string ChoiceText { get; private set; }

    /// <summary>
    /// Gets or sets the score associated with the interactable choice.
    /// </summary>
    [field: SerializeField] [JsonField("score")]
    public int Score { get; private set; }

    /// <summary>
    /// Gets or sets the possible follow-up scenario for the interactable choice.
    /// This can be null if there is no follow-up scenario.
    /// </summary>
    [field: SerializeField]
    public InteractableScenario PossibleFollowUpScenario { get; private set; }
}