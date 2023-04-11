using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScenarioManager : MonoBehaviour {
        [SerializeField] private List<InteractableScenario> interactableScenario;
        
        [SerializeField] private VideoManager videoManager;
        [SerializeField] private DialogueController dialogueController;
        [SerializeField] private ChoiceController choiceController;

        private Queue<InteractableScenario> scenarioQueue;

        private InteractableScenario currentScenario;

        private List<GameObject> loadedObjects = new List<GameObject>();
        
        private void Awake()
        {
            // add every element of interactableScenario to the queue
            scenarioQueue = new Queue<InteractableScenario>(interactableScenario);

            StartNextScenario();
        }

        private void StartNextScenario()
        {
            currentScenario = scenarioQueue.Dequeue();
            
            videoManager.PlayCutscene(currentScenario.CutScene);
        }

        public void StartDialogue()
        {
            Debug.Log("Starting dialogue");
            
            string directory = currentScenario.PrefabDirectory;

            GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs/" + directory);
            
            foreach (GameObject prefab in prefabs)
            {
               loadedObjects.Add(Instantiate(prefab));
            }
            
            
            dialogueController.StartDialogue(currentScenario.DialogueText);
            
            choiceController.InitializeChoices(currentScenario.Choices);
        }
        
        public void OnChoiceSelected(InteractableChoice choice)
        {
            bool hasFollowUp = choice.PossibleFollowUpScenario != null;
            
            ResetScene();
            
            // we want to remove this instance later and just use a reference
            ScoreManager.Instance.AddScore(choice.Score);
            
            if (scenarioQueue.Count == 0 && !hasFollowUp)
            {
                // end of game, switch user to end screen.
                Debug.Log("End of game");
                
                SceneController.SwitchScene("EndScene");
                return;
            }
            

            StartNextScenario();
        }

        private void ResetScene()
        {
            dialogueController.Disable();
            choiceController.Disable();
            
            loadedObjects.ForEach(Destroy);
            loadedObjects.Clear();
        }
}
