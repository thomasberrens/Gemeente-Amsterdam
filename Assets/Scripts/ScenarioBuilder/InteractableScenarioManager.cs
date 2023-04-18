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
        
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// This method initializes the scenario queue and starts the first scenario.
        /// </summary>
        private void Awake()
        {
            // add every element of interactableScenario to the queue
            scenarioQueue = new Queue<InteractableScenario>(interactableScenario);
            StartNextScenario();
        }

        /// <summary>
        /// Starts the next scenario in the queue. If there are no more scenarios, stops the game.
        /// </summary>
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
        
        /// <summary>
        /// Starts the given scenario by resetting the scene, setting the current scenario, and playing the cutscene.
        /// </summary>
        /// <param name="scenario">The InteractableScenario to start.</param>
        private void StartScenario(InteractableScenario scenario)
        {
            ResetScene();
            currentScenario = scenario;
            videoManager.PlayCutscene(scenario.CutScene);
        }

        /// <summary>
        /// Starts the dialogue for the current scenario if there is dialogue text and choices available.
        /// Instantiates prefabs and initializes the dialogue and choice controllers.
        /// </summary>
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

        /// <summary>
        /// Instantiates prefabs from a given directory in the Resources folder.
        /// </summary>
        /// <param name="directory">The directory path relative to the Resources folder.</param>
        private void InstantiatePrefabs(String directory)
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs/" + directory);

            foreach (GameObject prefab in prefabs)
            {
                loadedObjects.Add(Instantiate(prefab));
            }
        }
        
        /// <summary>
        /// Handles the selected choice, updates the score, and starts a follow-up scenario if it exists.
        /// If there is no follow-up scenario, starts the next scenario in the queue.
        /// </summary>
        /// <param name="choice">The InteractableChoice selected by the user.</param>
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

        /// <summary>
        /// Stops the game and switches to the end scene.
        /// </summary>
        private void StopGame()
        {
            Debug.Log("End of game");
                
            SceneController.SwitchScene("EndScene");
        }

        /// <summary>
        /// Resets the scene by disabling the dialogue and choice controllers, and clearing the loaded objects.
        /// </summary>
        private void ResetScene()
        {
            dialogueController.Disable();
            choiceController.Disable();
            
            loadedObjects.ForEach(Destroy);
            loadedObjects.Clear();
        }
}
