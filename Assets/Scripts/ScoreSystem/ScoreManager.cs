using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   public float CurrentScore {get; private set;}
   public static ScoreManager Instance { get; private set; }
   [field: SerializeField]public float MaxScore { get; private set; }
   [SerializeField] private InteractableScenarioManager interactableScenarioManager;
   

   /// <summary>
   /// Awake is called when the script instance is being loaded.
   /// This method initializes the singleton instance of the ScoreManager.
   /// </summary>
   private void Awake()
   {
      if (Instance == null) Instance = this;
      
      CalculateMaxScore();
      
      
   }

   public double CalculateCurrentRelativeScore()
   {
      float currentScore = Mathf.Min(CurrentScore, MaxScore);

      return Math.Round(currentScore / MaxScore * 10, 1);
   }

   private void CalculateMaxScore()
   {
      List<InteractableScenario> scenarios = interactableScenarioManager.InteractableScenarios;

      Dictionary<int, InteractableScenario> checkedScenarios = new Dictionary<int, InteractableScenario>();

      Queue<InteractableScenario> scenariosToCheck = new Queue<InteractableScenario>(scenarios);

      float maxScore = 0;
      

      while (scenariosToCheck.Count > 0) {
            InteractableScenario scenarioToCheck = scenariosToCheck.Dequeue();
            int hash = scenarioToCheck.GetHashCode();
            
            if (checkedScenarios.ContainsKey(hash)) continue;
            
            checkedScenarios.Add(hash, scenarioToCheck);
            
            InteractableChoice highestScoreChoice = GetChoiceWithHighestScore(scenarioToCheck);

            if (highestScoreChoice == null) continue;

            maxScore += highestScoreChoice.Score;

            bool hasFollowUp = highestScoreChoice.PossibleFollowUpScenario != null;
            
            if (hasFollowUp) scenariosToCheck.Enqueue(highestScoreChoice.PossibleFollowUpScenario);
      }
      
      
      MaxScore = maxScore;
   }
   
   private InteractableChoice GetChoiceWithHighestScore(InteractableScenario scenario)
   {
      int maxScore = 0;
      InteractableChoice maxChoice = null;
      
      scenario.Choices.ForEach(choice =>
      {
         if (choice.Score > maxScore)
         {
            maxScore = choice.Score;
            maxChoice = choice;
         }
      });

      return maxChoice;
   }

   /// <summary>
   /// Sets the score to the specified value.
   /// </summary>
   /// <param name="value">The value to set the score to.</param>
   public void SetScore(float value)
   {
      CurrentScore = value;
   }

   /// <summary>
   /// Adds the specified value to the current score.
   /// </summary>
   /// <param name="value">The value to add to the current score.</param>
   public void AddScore(float value)
   {
      CurrentScore += value;
   }

   /// <summary>
   /// Subtracts the specified value from the current score.
   /// </summary>
   /// <param name="value">The value to subtract from the current score.</param>
   public void SubtractScore(float value)
   {
      CurrentScore -= value;
   }

   /// <summary>
   /// Returns the current score.
   /// </summary>
   /// <returns>The current score as an integer.</returns>
   public float GetCurrentScore()
   {
      return CurrentScore;
   }
}