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
        if(detailsPanel.activeSelf && Input.GetKeyDown(KeyCode.I))
        {
            string url = $"https://rarible.com/token/polygon/0xfec50dae05902f4a1c303da8fb7477f7dea751d5:{hit.transform.parent.name}?tab=overview";
            Application.OpenURL(url);

        }
    }
}
