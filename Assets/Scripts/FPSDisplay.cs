using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    public TMP_Text display_Text;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}