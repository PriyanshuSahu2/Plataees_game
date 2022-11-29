using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Main Menu Navigation")]
    [SerializeField] GameObject i_LoadingPanel;
    [SerializeField] GameObject i_loginPanel;
    [SerializeField] GameObject i_registerPanel;
    [SerializeField] GameObject i_startPanel;
    [SerializeField] GameObject i_customizeWorld;
    [SerializeField] GameObject i_customizePanel;
    [SerializeField] GameObject i_ForgotPassword;
    [SerializeField] GameObject i_updatepanel;

    [Header("Loading Bar Settings")]
    [SerializeField] Image i_LoadingBar;
    [SerializeField] float splashScreenTimer = 3.8f;
    float loadbarFullTime = 0f;
    [SerializeField] LoadingLevel loadingLevel;

    [Header("Setting Panel Navigation")]
    [SerializeField] GameObject i_Profile;
    [SerializeField] GameObject i_SelectDistrict;
    [SerializeField] GameObject i_Settings;
    [SerializeField] GameObject i_Tutorial;
    [SerializeField] GameObject i_Language;
    [SerializeField] GameObject i_Friends;

    List<GameObject> AllPanels = new List<GameObject>();
    bool isFirst = true;
    void Start()
    {
        i_LoadingPanel.SetActive(true);
        AllPanels.Add(i_SelectDistrict);
        AllPanels.Add(i_Settings);
        AllPanels.Add(i_Profile);
    }

    // Update is called once per frame
    void Update()
    {
        if (i_LoadingPanel.activeSelf && isFirst)
        {

            if (splashScreenTimer <= 0)
            {
                if (PlayerPrefs.GetString("LogIn", "") == "")
                {
                    i_loginPanel.SetActive(true);
                }
                else
                {
                    onLoginBtn();
                }
               
                i_LoadingPanel.SetActive(false);
                isFirst = false;
            }
            else
            {
                loadbarFullTime += Time.deltaTime;
                i_LoadingBar.fillAmount = loadbarFullTime/3.8f;
                splashScreenTimer -= Time.deltaTime;
            }
            
        }
    }

    #region ---MainMenu Navigation---
    public void onLoginBtn()
    {
        i_startPanel.SetActive(true);
        i_loginPanel.SetActive(false);
    }

    public void onForgorPasswordBtn()
    {
        i_ForgotPassword.SetActive(true);
        i_loginPanel.SetActive(false);
    }
    public void onGoBack()
    {
        i_ForgotPassword.SetActive(false);
        i_loginPanel.SetActive(true);
    }
    public void onCreateAccountBtn()
    {
        i_registerPanel.SetActive(true);
        i_loginPanel.SetActive(false);
    }
    public void onSettingBtn()
    {
        i_startPanel.SetActive(false);
        i_customizePanel.SetActive(true);
    }
    public void onExitBtn()
    {
        i_customizePanel.SetActive(false);
        i_startPanel.SetActive(true);
    }
    public void onStartPanel()
    {
        i_LoadingPanel.SetActive(true);
        i_startPanel.SetActive(false);
        loadingLevel.StartCoroutine(loadingLevel.LoadLevel());
    }
    public void onRegisterBtn()
    {
        i_registerPanel.SetActive(false);
        i_loginPanel.SetActive(true);
    }
    public void RegisterLoginBtn()
    {
        i_registerPanel.SetActive(false);
        i_loginPanel.SetActive(true);
    }
    public void OnBackBtninProfilePanel()
    {
        i_Profile.SetActive(false);
        i_customizePanel.SetActive(false);
        i_customizeWorld.SetActive(false);
        i_startPanel.SetActive(true);
        i_updatepanel.SetActive(false);
    }
    public void OnCustomizeBtn()
    {
        i_customizePanel.SetActive(true);
        
        i_startPanel.SetActive(false);
    }
    public void OnUpdateBtn()
    {
        i_updatepanel.SetActive(true);
        
        i_startPanel.SetActive(false);
    }
    public void QuitBtn()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    #endregion


    #region ---Customize Naviagtion---
    public void ToggleAllPanels(GameObject newPanel)
    {
      foreach(GameObject gb in AllPanels)
        {
            if (gb!=null)
            {
                if (newPanel == gb)
                {
                    gb.SetActive(true);
                }
                else
                {
                    gb.SetActive(false);
                }
                
            }
        }
    }

    #endregion
}
