using TMPro;
using UnityEngine;

public class FrameRateCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI display;

    void Update()
    {
        float frameDuration = Time.unscaledDeltaTime;
        display.SetText("FPS\n{0:0}\n000\n000", 1f / frameDuration);
    }
}
