using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject i_LoadingPanel;
    [SerializeField] GameObject i_loginPanel;
    [SerializeField] GameObject i_registerPanel;
    [SerializeField] GameObject i_startPanel;
    [SerializeField] GameObject i_customizePanel;

    [SerializeField] float splashScreenTimer = 3.8f;

    [SerializeField] LoadingLevel loadingLevel;
    void Start()
    {
        i_LoadingPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (i_LoadingPanel.activeSelf)
        {

            if (splashScreenTimer <= 0)
            {
                i_loginPanel.SetActive(true);
                i_LoadingPanel.SetActive(false);
            }
            else
            {
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
        i_startPanel.SetActive(false);
        i_LoadingPanel.SetActive(true);
        loadingLevel.StartCoroutine(loadingLevel.LoadLevel());
    }
}
