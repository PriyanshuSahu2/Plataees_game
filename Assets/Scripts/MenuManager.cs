using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
public class MenuManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text Loading;

    [SerializeField] Button startBtn;
	
	bool isConnecting;

	string gameVersion = "1";

	[SerializeField] GameObject loadingPanel; 
	[SerializeField] Image loadingBar; 


	void Awake()
	{

		
		Invoke("CloseSpalsh", 5f);

	}

    private void Start()
    {
		PhotonNetwork.ConnectUsingSettings();
		PhotonNetwork.GameVersion = this.gameVersion;
	}

    void CloseSpalsh()
    {
		//spalshScreen.SetActive(false);

	}

	public void Connect()
	{

		//startBtn.interactable = false;
		//startBtn.GetComponentInChildren<TMP_Text>().text = "Loading...";

		isConnecting = true;



		if (PhotonNetwork.IsConnected)
		{
			
			PhotonNetwork.JoinRandomOrCreateRoom();
		}
		else
		{
			PhotonNetwork.ConnectUsingSettings();
			PhotonNetwork.GameVersion = this.gameVersion;
			// #Critical, we must first and foremost connect to Photon Online Server.

		}
	}







	public override void OnConnectedToMaster()
	{

		if (isConnecting)
		{
			
			Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room.\n Calling: PhotonNetwork.JoinRandomRoom(); Operation will fail if no room found");

			PhotonNetwork.JoinRandomOrCreateRoom();
		}
	}


	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		Debug.LogError(message);

		//PhotonNetwork.CreateRoom(null,new Photon.Realtime.RoomOptions { IsOpen = true });
	}


	public override void OnJoinedRoom()
	{
		Debug.Log(PhotonNetwork.CountOfPlayers);
		loadingPanel.SetActive(true);

		StartCoroutine(LoadLevel(1));
	}
	public void GetPlayerData()
    {
		
    }

	public IEnumerator LoadLevel(int levelIndex)
	{
		PhotonNetwork.LoadLevel(levelIndex);

		while (PhotonNetwork.LevelLoadingProgress < 1)
		{
			loadingBar.fillAmount = PhotonNetwork.LevelLoadingProgress +0.1f;
			yield return new WaitForEndOfFrame();
		}
		//LoadingMenu.SetActive(false);
		
		//PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), new Vector3(1397.821f, 102.4f, 593.1f), Quaternion.identity);
	}


}
