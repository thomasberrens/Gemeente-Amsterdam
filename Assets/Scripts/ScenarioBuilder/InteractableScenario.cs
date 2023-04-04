using UnityEditor;
using UnityEngine;

public class InteractableScenario : ScriptableObject {
        
    public string Name { get; private set; }
    public string TextToDisplay { get; private set; }
    
    
    
    [MenuItem("Assets/Create/InteractableScenarios")]
    public static void CreateAsset() => AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<InteractableScenario>(), "Assets/InteractableScenarios/NewInteractableScenario.asset");
    
}
