using UnityEngine;

public static class FunctionLibrary
{

    public static float Wave(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }
}