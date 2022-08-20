using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool gameIsPaused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) 
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
}
