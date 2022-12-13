using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName ="PlayerInfo",menuName ="PlayerInfo")]
public class PlayerData :MonoBehaviour
{
    public static int languageId = 1;
    public static string token;
    public static string name;
    public static string last_name;
    public static string date_birth;
    public static string user_name;
    public static string email;
    public static string nick_name;
    public static string wallet;
    public static string genderId = "1";

    public void SetPlayerInfo(LoginUserData loginUserData)
    {
        name = loginUserData.name;
       
        last_name = loginUserData.last_name;
        date_birth = loginUserData.date_birth;
        user_name = loginUserData.user_name;
        email = loginUserData.email;
        nick_name = loginUserData.nick_name;
        token = loginUserData.token;
        genderId = loginUserData.genderId;
        PlayerPrefs.SetString("PlayerGender", genderId == "1" ? "MPlayer" : "FPlayer");
        Debug.Log(name + " " + last_name);
    }
    public void GetPlayerInfo()
    {
        StartCoroutine(GetPlayerData());
    }
    IEnumerator GetPlayerData()
    {
        string uri ="https://apiplatzeeland.platzees.io/api/users/"+user_name;
        UnityWebRequest req = new UnityWebRequest(uri, "GET");
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("Authorization", "Bearer " + PlayerPrefs.GetString("Token"));
        yield return req.SendWebRequest();

        if(req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(req.error);
        }
        else
        {
            string res = req.downloadHandler.text;
            Status status = JsonUtility.FromJson<Status>(res);
            if(status.body.code == "1")
            {
                var playerInfo = status.body.data;
                name = playerInfo.name;
                email = playerInfo.email;
                genderId = playerInfo.genderId;
            }

        }
    }

    [Serializable]
    public class Status
    {
        public string error;
        public string status;
        public Body body;
    }

    [Serializable]
    public class Body
    {
        public string code;
        public UserData data;
    }
    [Serializable]
    public class UserData
    {
        public string languageId;
        public string name;
        public string last_name;
        public string date_birth;
        public string user_name;
        public string email;
        public string wallet;
        public string genderId;
    }
}
