using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Main Menu Navigation")]
    [SerializeField] GameObject i_LoadingPanel;
    [SerializeField] GameObject i_loginPanel;
    [SerializeField] GameObject VersionChecker;
    [SerializeField] GameObject i_registerPanel;
    [SerializeField] GameObject i_startPanel;
    [SerializeField] GameObject i_customizePanel;
    [SerializeField] GameObject i_ForgotPassword;
    [SerializeField] GameObject i_updatepanel;
    [SerializeField] GameObject i_SettingsPanel;

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
    string installedVersion;
    string currentVersion;
    void Start()
    {
        installedVersion = Application.version;
        StartCoroutine(GetCurrentVersion());
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
                    if (currentVersion == installedVersion)
                    {
                        i_loginPanel.SetActive(true);
                    }
                    else
                    {
                        VersionChecker.SetActive(true);
                    }
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
     IEnumerator GetCurrentVersion()
    {
        string uri = "https://apiplatzeeland.platzees.io/api/version/latest";
        UnityWebRequest req = new UnityWebRequest(uri, "GET");
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(req.error);
        }
        else
        {
            string res = req.downloadHandler.text;
            Status status = JsonUtility.FromJson<Status>(res);
         
            if (status.body.code == "1")
            {
                var info = status.body.data;
                currentVersion = info.version;
                Debug.Log(currentVersion);
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
    public void onCustomizeBtn()
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
        i_startPanel.SetActive(true);
        i_Profile.SetActive(false);
        i_customizePanel.SetActive(false);
        i_updatepanel.SetActive(false);
        i_SettingsPanel.SetActive(false);
    }
    public void OnCustomizeBtn()
    {
        i_customizePanel.SetActive(true);
        i_startPanel.SetActive(false);
    }
    public void OnSettingsBtn()
    {
        i_SettingsPanel.SetActive(true);
        i_startPanel.SetActive(false);
    }
    public void OnUpdateBtn()
    {
        i_updatepanel.SetActive(true);
        
        i_startPanel.SetActive(false);
    }
    public void QuitBtn()
    {
        
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


    [Serializable]
    public class Status
    {
        public string error;
        public string status;
        public Body body;
    }

    [Serializable]
    public class Body
    {
        public string code;
        public Data data;
    }
    [Serializable]
    public class Data
    {
        public string version;
        public string creation_date;
    }
}
