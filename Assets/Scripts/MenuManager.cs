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

	[SerializeField] GameObject spalshScreen; 


	void Awake()
	{

		PhotonNetwork.AutomaticallySyncScene = false;
		Invoke("CloseSpalsh", 5f);

	}


	void CloseSpalsh()
    {
		spalshScreen.SetActive(false);

	}

	public void Connect()
	{

		//startBtn.interactable = false;
		//startBtn.GetComponentInChildren<TMP_Text>().text = "Loading...";

		isConnecting = true;



		if (PhotonNetwork.IsConnected)
		{
			PhotonNetwork.JoinRandomRoom();
		}
		else
		{

			// #Critical, we must first and foremost connect to Photon Online Server.
			PhotonNetwork.ConnectUsingSettings();
			PhotonNetwork.GameVersion = this.gameVersion;
		}
	}







	public override void OnConnectedToMaster()
	{

		if (isConnecting)
		{
			
			Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room.\n Calling: PhotonNetwork.JoinRandomRoom(); Operation will fail if no room found");

			PhotonNetwork.JoinRandomRoom();
		}
	}


	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		PhotonNetwork.CreateRoom(null);
	}


	public override void OnJoinedRoom()
	{

		
		if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
		{
			Debug.Log("We load the 'Room for 1' ");

			StartCoroutine(LoadLevel(1));
			
		}
	}

	public IEnumerator LoadLevel(int levelIndex)
	{
		PhotonNetwork.LoadLevel(levelIndex);
		while (PhotonNetwork.LevelLoadingProgress < 1)
		{
			yield return new WaitForEndOfFrame();
		}
		//LoadingMenu.SetActive(false);
		Debug.LogError("FUCK NOW");
		PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), new Vector3(1397.821f, 102.4f, 593.1f), Quaternion.identity);
	}


}
