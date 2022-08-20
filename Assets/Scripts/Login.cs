using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField password;
    [SerializeField] MainMenu mainMenu;
    private LoginWithEmailPass loginWithEmailPass;
    private LoginUserData loginUserData;
    private LoginStatus loginStatus;
    public void OnLoginButton()
    {
        loginWithEmailPass = new LoginWithEmailPass();
        loginUserData = new LoginUserData();
        loginStatus = new LoginStatus();
        loginWithEmailPass.type = 1;
        loginWithEmailPass.value_type = email.text;
        loginWithEmailPass.password = password.text;
        StartCoroutine(LoginUser_Coroutine());
    }
    IEnumerator LoginUser_Coroutine()
    {
        string uri = "https://apiplatzeeland.platzees.io/api/auth";

        var json = JsonUtility.ToJson(loginWithEmailPass);
        UnityWebRequest req = new UnityWebRequest(uri, "POST");
        byte[] rawData = System.Text.Encoding.UTF8.GetBytes(json);
        req.uploadHandler = new UploadHandlerRaw(rawData);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(req.error);
        }
        else
        {

            string res = req.downloadHandler.text;
            //loginUserData = JsonUtility.FromJson<LoginUserData>(res);
            loginStatus = JsonUtility.FromJson<LoginStatus>(res);
            if (loginStatus.body.code == "1")
            {
                mainMenu.onLoginBtn();
            }
        }



    }
}

[Serializable]
public class LoginWithEmailPass
{
    public int type = 1;
    public string value_type;
    public string password;

}
[Serializable]
public class LoginStatus
{
    public string error;
    public string status;
    public LoginBody body;
    
}

[Serializable]
public class LoginBody
{
    public string code;
    public LoginUserData data;
}

[Serializable]
public class LoginUserData
{
    public string token;
    public string user_name;
    public string genderId;
    public string name;
    public string last_name;
    public string date_birth;
    public string email;
    public string nick_name;
}

