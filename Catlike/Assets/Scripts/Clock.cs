using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    private void Awake()
    {
        hoursPivot.localRotation = Quaternion.Euler(0, 0, -30);
    }
}