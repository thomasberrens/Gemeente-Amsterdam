using UnityEngine;

/// <summary>
/// Contains various easing functions for interpolation and animation.
/// </summary>
public class EaseFunctions
{
    
    public static float Linear(float t)
    {
        return t;
    }

    public static float EaseInQuad(float t)
    {
        return t * t;
    }

    public static float EaseOutQuad(float t)
    {
        return 1 - (1 - t) * (1 - t);
    }

    public static float EaseInOutQuad(float t)
    {
        return t < 0.5f ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
    }

    public static float EaseInCubic(float t)
    {
        return t * t * t;
    }

    public static float EaseOutCubic(float t)
    {
        float f = t - 1;
        return f * f * f + 1;
    }

    public static float EaseInOutCubic(float t)
    {
        return t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
    }

    public static float EaseInQuart(float t)
    {
        return t * t * t * t;
    }

    public static float EaseOutQuart(float t)
    {
        float f = t - 1;
        return f * f * f * (1 - t) + 1;
    }

    public static float EaseInOutQuart(float t)
    {
        return t < 0.5f ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
    }

    public static float EaseInQuint(float t)
    {
        return t * t * t * t * t;
    }

    public static float EaseOutQuint(float t)
    {
        float f = t - 1;
        return f * f * f * f * f + 1;
    }

    public static float EaseInOutQuint(float t)
    {
        return t < 0.5f ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
    }

    public static float EaseInSine(float t)
    {
        return Mathf.Sin((t - 1) * Mathf.PI / 2) + 1;
    }

    public static float EaseOutSine(float t)
    {
        return Mathf.Sin(t * Mathf.PI / 2);
    }

    public static float EaseInOutSine(float t)
    {
        return (1 - Mathf.Cos(t * Mathf.PI)) / 2;
    }

    public static float EaseInExpo(float t)
    {
        return Mathf.Pow(2, 10 * (t - 1));
    }

    public static float EaseOutExpo(float t)
    {
        return 1 - Mathf.Pow(2, -10 * t);
    }

    public static float EaseInOutExpo(float t)
    {
        t /= 0.5f;
        if (t < 1) return Mathf.Pow(2, 10 * (t - 1)) / 2;
        t--;
        return (2 - Mathf.Pow(2, -10 * t)) / 2;
    }

    public static float EaseInCirc(float t)
    {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
    }
}
