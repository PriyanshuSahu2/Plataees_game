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
        StartCoroutine(LoadLevel(levelIndex));
        //LoadingMenu.SetActive(true);
       // StartCoroutine(LoadLevel(levelIndex));
    }
    public IEnumerator LoadLevel(int levelIndex)
    {
        PhotonNetwork.LoadLevel(levelIndex);
        while (PhotonNetwork.LevelLoadingProgress<1)
        {

            
            yield return new WaitForEndOfFrame();
        }
        //LoadingMenu.SetActive(false);
      //  Debug.LogError("Not Stopped");
      //  PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), new Vector3(1397.821f, 102.4f, 593.1f), Quaternion.identity);
    }
}
