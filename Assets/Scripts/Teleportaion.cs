using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportaion : MonoBehaviour
{
    [SerializeField] float radius=3f;
    [SerializeField] GameObject player;
    [SerializeField] float pos;
    [SerializeField] GameObject teleportationMenu;
    bool havEntered = false;

    void Start()
    {
        
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

}
