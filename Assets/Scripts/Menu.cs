using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject menu;
    [SerializeField] public GameObject map;
   
    private void Start()
    {
        menu.SetActive(false);
        map.SetActive(false);
      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            Time.timeScale = 1f;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                menu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }
    public void Resume()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
    public void exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
