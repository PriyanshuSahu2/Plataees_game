using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class PlayerLabel : MonoBehaviour
{
    // Start is called before the first frame update
    PhotonView pv;
    [SerializeField] TMP_Text name;
    void Start()
    {
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            name.gameObject.SetActive(false);
        }

            name.text = pv.Owner.NickName;
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
