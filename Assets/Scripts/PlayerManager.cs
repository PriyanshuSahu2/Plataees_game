using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviourPunCallbacks
{
   
    PhotonView Pv;
    GameObject spawnManager;
    private void Awake()
    {
        Pv = GetComponent<PhotonView>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
    }
    void Start()
    {
        if (Pv.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
       // Transform spawnpoint = spawnManager.GetComponent<SpawnManager>().GetSpawnPoint();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"),new Vector3(56.01f, 3.67f, 71.67f) , Quaternion.identity);
    }
}
//Vector3(-22.4094391,-1.90376055,18.7973022)