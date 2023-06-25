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

        Fractal childA = CreateChild(Vector3.up);
        Fractal childB = CreateChild(Vector3.right);

        childA.transform.SetParent(transform, false);
        childB.transform.SetParent(transform, false);
    }

    Fractal CreateChild(Vector3 direction)
    {
        Fractal child = Instantiate(this);
        child.depth = depth - 1;
        child.transform.localPosition = 0.75f * direction;
        child.transform.localScale = 0.5f * Vector3.one;
        return child;
    }
}