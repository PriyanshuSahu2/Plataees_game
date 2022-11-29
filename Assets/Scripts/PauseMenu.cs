using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inGamecontrolPanel;
    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject chatPanel;
    [SerializeField] GameObject map;
    [SerializeField] float countDown = 15;
  
    public static bool gameIsPaused = false;
    private void Start()
    {
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
        Time.timeScale = 1;
        Application.Quit();
    }
    public void onMapBtn()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        map.SetActive(true);
        Time.timeScale = 0f;
    }
    public void onControlBtn()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        controlPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void onBackBtn()
    {
        pauseMenu.SetActive(true);
        map.SetActive(false);
        controlPanel.SetActive(false);
    }

}
