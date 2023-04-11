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

   private void Awake()
   {
      if (Instance == null) Instance = this;
   }

   public void SetScore(int value)
   {
      CurrentScore = value;
   }

   public void AddScore(int value)
   {
      CurrentScore += value;
   }

   public void SubtractScore(int value)
   {
      CurrentScore -= value;
   }

   public int GetCurrentScore()
   {
      return CurrentScore;
   }
}