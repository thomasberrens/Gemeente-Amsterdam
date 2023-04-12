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

            if (scenarioQueue.Count == 0)
            {
                // end of game, switch user to end screen.
                StopGame();
                return;
            }
            
            StartScenario(scenarioQueue.Dequeue());
        } 
        
        private void StartScenario(InteractableScenario scenario)
        {
            ResetScene();
            currentScenario = scenario;
            videoManager.PlayCutscene(scenario.CutScene);
        }

        public void StartDialogue()
        {
            Debug.Log("Starting dialogue");

            bool showDialogue = currentScenario.DialogueText != null &&
                                currentScenario.DialogueText.Trim().Length > 0 &&
                                currentScenario.Choices?.Count > 0;

            if (!showDialogue)
            {
                StartNextScenario();
                return;
            }
            
            string directory = currentScenario.PrefabDirectory;
            
            InstantiatePrefabs(directory);
            
            dialogueController.StartDialogue(currentScenario.DialogueText);
            
            choiceController.InitializeChoices(currentScenario.Choices);
        }

        private void InstantiatePrefabs(String directory)
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs/" + directory);

            foreach (GameObject prefab in prefabs)
            {
                loadedObjects.Add(Instantiate(prefab));
            }
        }
        
        public void OnChoiceSelected(InteractableChoice choice)
        {
            bool hasFollowUp = choice.PossibleFollowUpScenario != null;
            
            // we want to remove this instance later and just use a reference
            ScoreManager.Instance.AddScore(choice.Score);

            if (hasFollowUp)
            {
                StartScenario(choice.PossibleFollowUpScenario);
                return;
            }

            StartNextScenario();
        }

        private void StopGame()
        {
            Debug.Log("End of game");
                
            SceneController.SwitchScene("EndScene");
        }

        private void ResetScene()
        {
            dialogueController.Disable();
            choiceController.Disable();
            
            loadedObjects.ForEach(Destroy);
            loadedObjects.Clear();
        }
}
