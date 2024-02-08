using System.IO;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager _instance;
    
   
    private void Awake()
    {
        PhotonNetwork.KeepAliveInBackground = 160000;
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex !=0)
        {
            GameObject gb = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }

    void Start()
    {   
        PlayerPrefs.DeleteKey("LogIn");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
