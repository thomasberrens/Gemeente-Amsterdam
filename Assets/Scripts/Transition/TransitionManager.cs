using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private Image transitionImage;
    [SerializeField] private float transitionDuration = 1f;

    private Coroutine currentTransition;

    /// <summary>
    /// Starts a transition animation.
    /// </summary>
    public void StartTransition()
    {
        if (currentTransition != null)
        {
            StopCoroutine(currentTransition);
        }

        currentTransition = StartCoroutine(DoTransition());
    }

    /// <summary>
    /// Coroutine that handles the transition animation.
    /// </summary>
    private IEnumerator DoTransition()
    {
        Color startColor = Color.black;
        Color endColor = Color.clear;
        float timer = 0f;

        while (timer < transitionDuration)
        {
            float t = timer / transitionDuration;
            float easedT = EaseFunctions.EaseInCubic(t);
            transitionImage.color = Color.Lerp(startColor, endColor, easedT);

            yield return null;
            timer += Time.deltaTime;
        }

        transitionImage.color = endColor;
    }
}