
    using UnityEngine;
    

    [CreateAssetMenu(fileName = "New Interactable Choice", menuName = "Interactable Choice")]
    public class InteractableChoice : ScriptableObject
    {
        [field: SerializeField] [JsonField("choice")] public string ChoiceText { get; private set; }
        [field: SerializeField] [JsonField("score")] public int Score { get; private set; }

        // This is a possible follow up scenario (it can be null!)
        [field: SerializeField] public InteractableScenario PossibleFollowUpScenario { get; private set; }
    }
