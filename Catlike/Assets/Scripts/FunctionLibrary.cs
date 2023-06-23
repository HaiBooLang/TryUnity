using UnityEngine;

using static UnityEngine.Mathf;

public static class FunctionLibrary
{

    public delegate float Function(float x, float t);

    public enum FunctionName { Wave, MultiWave, Ripple }

    static Function[] functions = { Wave, MultiWave, Ripple };

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    public static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }

    public static float MultiWave(float x, float t)
    {
        float y = Sin(PI * (x + t));
        y += 0.5f * Sin(2f * PI * (x + t));
        return y * (2f / 3f);
    }

    public static float Ripple(float x, float t)
    {
        float d = Abs(x);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }
}