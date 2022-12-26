using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inGamecontrolPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject chatPanel;
    [SerializeField] GameObject map;
    [SerializeField] float countDown = 15;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Image loadingBar;
    public static bool gameIsPaused = false;
    [SerializeField] GameObject cam;
    private void Start()
    {
        cam.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inGamecontrolPanel.SetActive(true);
        pauseMenu.SetActive(false);
        map.SetActive(false);

    }
    
    void Update()
    {
        if (inGamecontrolPanel.activeSelf)
        {
            if (countDown <= 0)
            {
                inGamecontrolPanel.SetActive(false);

            }
            else
            {
                countDown -= Time.deltaTime;
            }
        }
        if (chatPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                chatPanel.SetActive(false);
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
           
            if (pauseMenu.activeSelf)
            {
                onResumeBtn();  
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map.activeSelf)
            {
                map.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                map.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }
    public void onResumeBtn()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }
    public void onQuitBtn()
    {
        cam.SetActive(true);
        Time.timeScale = 1;
        loadingPanel.SetActive(true);
        PhotonNetwork.Disconnect();
        StartCoroutine(LoadLevel(0));
        
    }
    public void onMapBtn()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        map.SetActive(true);
        Time.timeScale = 0f;
    }
    public void onSettingsBtn()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void onBackBtn()
    {
        pauseMenu.SetActive(true);
        map.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public IEnumerator LoadLevel(int levelIndex)
    {
        var i = SceneManager.LoadSceneAsync(0);

        while (i.progress < 1)
        {
            loadingBar.fillAmount = i.progress + 0.1f;
            yield return new WaitForEndOfFrame();
        }
        //LoadingMenu.SetActive(false);

        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), new Vector3(1397.821f, 102.4f, 593.1f), Quaternion.identity);
    }

}
