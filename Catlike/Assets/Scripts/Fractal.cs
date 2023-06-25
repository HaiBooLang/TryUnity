using UnityEngine;

public class Fractal : MonoBehaviour
{

    [SerializeField, Range(1, 8)]
    int depth = 4;

    void Start()
    {
        name = "Fractal " + depth;
        if (depth <= 1)
        {
            return;
        }

        Fractal child = Instantiate(this);
        child.depth = depth - 1;
        child.transform.SetParent(transform, false);
        child.transform.localPosition = 0.75f * Vector3.right;
        child.transform.localScale = 0.5f * Vector3.one;
    }
}