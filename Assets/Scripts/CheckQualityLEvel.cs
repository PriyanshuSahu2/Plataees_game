using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckQualityLEvel : MonoBehaviour
{
    // Start is called before the first frame update

    public int avgFrameRate;
    public TMP_Text fps;
    public TMP_Text displayCurrentQuality;
    int qualityLevel;
    void Start()
    {
        qualityLevel = QualitySettings.GetQualityLevel();
        displayCurrentQuality.text = qualityLevel.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        fps.text = avgFrameRate.ToString() + " FPS";
        
        if (Input.GetKey(KeyCode.F1))
        {
            QualitySettings.SetQualityLevel(1);
            qualityLevel = QualitySettings.GetQualityLevel();
            displayCurrentQuality.text = qualityLevel.ToString();
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            QualitySettings.SetQualityLevel(2);
            qualityLevel = QualitySettings.GetQualityLevel();
            displayCurrentQuality.text = qualityLevel.ToString();
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            QualitySettings.SetQualityLevel(3);
            qualityLevel = QualitySettings.GetQualityLevel();
            displayCurrentQuality.text = qualityLevel.ToString();
        }
        else if (Input.GetKey(KeyCode.F4))
        {
           
            QualitySettings.SetQualityLevel(4);
            qualityLevel = QualitySettings.GetQualityLevel();
            displayCurrentQuality.text = qualityLevel.ToString();
        }
        else if (Input.GetKey(KeyCode.F5))
        {
            QualitySettings.SetQualityLevel(5);
            qualityLevel = QualitySettings.GetQualityLevel();
            displayCurrentQuality.text = qualityLevel.ToString();
        }
    }
}
