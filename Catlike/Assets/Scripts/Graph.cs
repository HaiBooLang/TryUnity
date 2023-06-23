using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{

    [SerializeField]
    Transform pointPrefab;
    
    [SerializeField, Range(10,100)]
    int resolution = 10;

    void Awake()
    {
        Vector3 position = Vector3.zero;
        var scale = Vector3.one / 5f;
        for (int i = 0; i < 10; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) / 5f - 1f;
            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    }
}
