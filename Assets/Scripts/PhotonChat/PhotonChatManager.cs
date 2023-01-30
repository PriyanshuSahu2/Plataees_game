using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class PhotonChatManager : MonoBehaviour,IChatClientListener
{
    

    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    public void OnChatStateChange(ChatState state)
    {
      
    }

    public void OnConnected()
    {
        Debug.Log("Connected");
        chatClient.Subscribe(new string[] { "RegionChannel" });
    }

    public void OnDisconnected()
    {
        Debug.Log("Disconnected");
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";
        for(int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("<color=red>{0}</color>: {1}", senders[i], messages[i]);
            chatDisplay.text += "\n " + msgs;
            Debug.Log(msgs);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
       
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
       
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        
    }

    public void OnUnsubscribed(string[] channels)
    {
        
    }

    public void OnUserSubscribed(string channel, string user)
    {
        
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        
    }

    // Start is called before the first frame update
    [SerializeField]string username;
    ChatClient chatClient;

    [SerializeField] GameObject chatPanel;
    [SerializeField] TMP_InputField inputPanel;
    [SerializeField] TMP_Text chatDisplay;
    bool isConnected;
    private EventSystem eventSystem;
    string currenChat;
    void Start()
    {
        chatClient = new ChatClient(this);
        username = PlayerPrefs.GetString("PlayerName", "Player");
        eventSystem = EventSystem.current;
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(username));
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (chatPanel.activeSelf)
            {
                eventSystem.SetSelectedGameObject(null);
                chatPanel.SetActive(false);
            }
            else
            {
                chatPanel.SetActive(true);
                eventSystem.SetSelectedGameObject(inputPanel.gameObject);
                inputPanel.ActivateInputField();
            }
        }
        if(Input.GetKeyDown(KeyCode.Return) && chatPanel.activeSelf)
        {
            send();
        }
        chatClient.Service();
    }
    public void send()
    {
        chatClient.PublishMessage("RegionChannel", currenChat);
        inputPanel.text = "";
        currenChat = "";
        inputPanel.Select();
        inputPanel.ActivateInputField();

    }

    public void TypeChatOnValueChange(string valueIn)
    {
        currenChat = valueIn;
    }

}
