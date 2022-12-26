using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
public class Teleportaion : MonoBehaviour
{
    [SerializeField] float radius=3f;
    [SerializeField] GameObject player;
    [SerializeField] float pos;
    [SerializeField] GameObject teleportationMenu;
    [SerializeField] GameObject LoadingMenu;
    [SerializeField] Image m_ProgreesBar;
    [SerializeField] GameObject teleportationPanel;
    bool havEntered = false;

    private void Awake()
    {
       // LoadingMenu.SetActive(false);
    }
    void Start()
    {
       // LoadingMenu.SetActive(false);
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
            teleportationPanel.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            havEntered = false;
            teleportationPanel.SetActive(false);
        }
        teleportationMenu.SetActive(false);
    }
   
    public void TeleportationLevel(int levelIndex)
    {
        //LoadingMenu.SetActive(true);
        Debug.Log("Passed");
        
        LoadingMenu.SetActive(true);
        StartCoroutine(LoadLevel(levelIndex));
        
        
    }
    public IEnumerator LoadLevel(int levelIndex)
    {
        PhotonNetwork.LoadLevel(levelIndex);

        while (PhotonNetwork.LevelLoadingProgress<1)
        {
            m_ProgreesBar.fillAmount = PhotonNetwork.LevelLoadingProgress;
            yield return new WaitForEndOfFrame();
        }
        LoadingMenu.SetActive(false);
        m_ProgreesBar.fillAmount = 0;
        // Debug.LogError("Not Stopped");
    }
    public void D()
    {
        Debug.Log("SKSK");
    }
}
