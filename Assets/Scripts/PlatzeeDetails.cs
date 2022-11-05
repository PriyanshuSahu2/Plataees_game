using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatzeeDetails : MonoBehaviour
{
    [SerializeField] GameObject check;
    [SerializeField] GameObject detailsPanel;
    [SerializeField] TMP_Text platzeeName;
    [SerializeField] LayerMask layerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            if (!detailsPanel.activeSelf)
            {
                platzeeName.text ="Platzee #"+ hit.transform.parent.name;
                detailsPanel.SetActive(true);
            }
        }
        else
        {
            if (detailsPanel.activeSelf)
            {
                detailsPanel.SetActive(false);
            }
        }
    }
}
