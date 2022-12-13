using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;
public class PhotonManage : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] GameObject playerRoot;
    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject miniMapCam;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject check;
    [SerializeField] GameObject followCam;
    PhotonView pv;
    [SerializeField] GameObject cam;
    
    void Start()
    {

        pv = GetComponent<PhotonView>();
        
        if (!pv.IsMine)
        {
            Destroy(cam);
            Destroy(cinemachineVirtualCamera);
            Destroy(playerRoot);
            Destroy(miniMap);
            Destroy(miniMapCam);
            Destroy(canvas);
            Destroy(check);
        }
        cinemachineVirtualCamera.LookAt = playerRoot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
