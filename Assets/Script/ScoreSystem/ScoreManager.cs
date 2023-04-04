using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public int CurrentScore {get; private set;}

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