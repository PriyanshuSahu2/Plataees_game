using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
    // Start is called before the first frame update
    #region ---Resolution -- 
    [Header("Resolutions")]
    [SerializeField] List<string> resolution = new List<string>();
    [SerializeField] List<Resolution> res = new List<Resolution>();
    [SerializeField] TMP_Dropdown resolutionDropdown;
    private Resolution currResolution;
    #endregion
    [Header("Shadow Quality")]
    [SerializeField] List<string> shaodwQuality = new List<string>();
    [SerializeField] TMP_Dropdown shaodowQualityDropdown;

    [Header("Render Distance")]
    [SerializeField] float renderDistance =500;
    [SerializeField] Slider renderDistanceSlider;
    [SerializeField] TMP_Text sliderBox;

    [Header("")]
    [SerializeField] GameObject showFps;
    void OnEnable()
    {
       GetResolutionSettings();
       GetShadowSettings();
       GetRenderDistance();
    }


    #region --Resolution Settings--
    private void GetResolutionSettings()
    {
        currResolution = Screen.currentResolution;
        foreach (Resolution rs in Screen.resolutions)
        {
            resolution.Add(rs.width + "x" + rs.height);
            res.Add(rs);
        }
        resolution.Reverse();
        res.Reverse();
        resolutionDropdown.AddOptions(resolution);
        int temp = 0;
        foreach (string s in resolution)
        {
            if (s == (currResolution.width + "x" + currResolution.height))
            {
                resolutionDropdown.value = temp;
            }
            temp++;
        }
    }
    public void SetResolution()
    {
        Resolution currValue = res[resolutionDropdown.value];
        Screen.SetResolution(currValue.width, currValue.height, true);
    }
    #endregion

    #region --Shadow Settings--
    private void GetShadowSettings()
    {
        shaodowQualityDropdown.AddOptions(shaodwQuality);
        shaodowQualityDropdown.value = QualitySettings.GetQualityLevel();
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void SetShadowSettings()
    {
        QualitySettings.SetQualityLevel(shaodowQualityDropdown.value);
    }
    #endregion

    #region --Render Distance--
    private void GetRenderDistance()
    {
        renderDistance = PlayerPrefs.GetFloat("RenderDistance", 500f);
        sliderBox.text = renderDistance.ToString();
        renderDistanceSlider.value = renderDistance;
    }
    public void SetRenderDistnace()
    {
        PlayerPrefs.SetFloat("RenderDistance", renderDistanceSlider.value);
        renderDistance = renderDistanceSlider.value;
        sliderBox.text = renderDistanceSlider.value.ToString() +"mt";
    }
    #endregion

    #region -- ShowFps--
    private void GetShowFps()
    {
        if (PlayerPrefs.GetInt("ShowFPS", 1)==1)
        {
            showFps.SetActive(true);
        }
        else
        {
            showFps.SetActive(false);
        }
    }
    public void SetShowFps()
    {
        if (showFps.activeSelf)
        {
            PlayerPrefs.SetInt("ShowFPS", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ShowFPS", 0);
        }
    }
    #endregion

}
