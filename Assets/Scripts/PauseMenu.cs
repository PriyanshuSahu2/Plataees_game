using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject map;
  
    public static bool gameIsPaused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
        map.SetActive(false);

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

}
