using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;
public class PhotonManage : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] GameObject playerRoot;
    PhotonView pv;
    [SerializeField] Camera cam;
    void Start()
    {
        pv = GetComponent<PhotonView>();
      
        if (!pv.IsMine)
        {
            Destroy(cam);
            Destroy(cinemachineVirtualCamera);
            Destroy(playerRoot);
        }
       cinemachineVirtualCamera.LookAt = playerRoot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
