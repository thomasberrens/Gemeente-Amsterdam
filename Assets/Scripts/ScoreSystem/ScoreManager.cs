using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public int CurrentScore {get; private set;}
   public static ScoreManager Instance { get; private set; }
   [field: SerializeField]public int MaxScore { get; private set; }

   /// <summary>
   /// Awake is called when the script instance is being loaded.
   /// This method initializes the singleton instance of the ScoreManager.
   /// </summary>
   private void Awake()
   {
      if (Instance == null) Instance = this;
   }

   /// <summary>
   /// Sets the score to the specified value.
   /// </summary>
   /// <param name="value">The value to set the score to.</param>
   public void SetScore(int value)
   {
      CurrentScore = value;
   }

   /// <summary>
   /// Adds the specified value to the current score.
   /// </summary>
   /// <param name="value">The value to add to the current score.</param>
   public void AddScore(int value)
   {
      CurrentScore += value;
   }

   /// <summary>
   /// Subtracts the specified value from the current score.
   /// </summary>
   /// <param name="value">The value to subtract from the current score.</param>
   public void SubtractScore(int value)
   {
      CurrentScore -= value;
   }

   /// <summary>
   /// Returns the current score.
   /// </summary>
   /// <returns>The current score as an integer.</returns>
   public int GetCurrentScore()
   {
      return CurrentScore;
   }
}