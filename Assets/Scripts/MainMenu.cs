using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject i_LoadingPanel;
    [SerializeField] GameObject i_loginPanel;
    [SerializeField] GameObject i_registerPanel;
    [SerializeField] GameObject i_startPanel;
    [SerializeField] GameObject i_customizePanel;
    [SerializeField] Image i_LoadingBar;

    [SerializeField] float splashScreenTimer = 3.8f;
    float loadbarFullTime = 0f;
    [SerializeField] LoadingLevel loadingLevel;

    bool isFirst = true;
    void Start()
    {
        i_LoadingPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (i_LoadingPanel.activeSelf && isFirst)
        {

            if (splashScreenTimer <= 0)
            {
                i_loginPanel.SetActive(true);
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

    public void onLoginBtn()
    {
        i_startPanel.SetActive(true);
        i_loginPanel.SetActive(false);
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
}
