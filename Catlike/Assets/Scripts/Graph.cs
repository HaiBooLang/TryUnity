using UnityEngine;

public class Graph : MonoBehaviour
{

    [SerializeField]
    Transform pointPrefab;

    void Awake()
    {
        for(int i = 0; i <10; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localPosition = Vector3.right * i;
        }
    }
}
