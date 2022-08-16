using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportaion : MonoBehaviour
{
    [SerializeField] float radius=3f;
    [SerializeField] GameObject player;
    [SerializeField] float pos;
    [SerializeField] GameObject teleportationMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.gameObject.CompareTag("Player"))
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
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            Debug.Log("Did not Hit");
        }
    }

    
}
