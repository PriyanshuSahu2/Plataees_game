using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Teleportaion : MonoBehaviour
{
    [SerializeField] float radius=3f;
    [SerializeField] GameObject player;
    [SerializeField] float pos;
    [SerializeField] GameObject teleportationMenu;
    [SerializeField] GameObject LoadingMenu;
    [SerializeField] Image m_ProgreesBar;
    bool havEntered = false;

    private void Awake()
    {
        LoadingMenu.SetActive(false);
    }
    void Start()
    {
        LoadingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (havEntered)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                    if (!teleportationMenu.activeSelf)
                    {
                        teleportationMenu.SetActive(true);
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                    }
                    else
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                        teleportationMenu.SetActive(false);
                    }
            
            }

        }
        else
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            havEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            havEntered = false;
        }
    }
    public void TeleportationLevel(int levelIndex)
    {
        LoadingMenu.SetActive(true);
        StartCoroutine(LoadLevel(levelIndex));
    }
    public IEnumerator LoadLevel(int levelIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelIndex);
        while (!asyncOperation.isDone)
        {
            m_ProgreesBar.fillAmount = asyncOperation.progress + 0.1f;
            yield return null;
        }
        LoadingMenu.SetActive(false);
        yield return null;
    }
}
