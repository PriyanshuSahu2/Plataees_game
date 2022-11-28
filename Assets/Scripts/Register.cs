using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
    [SerializeField] TMP_InputField first_name;
    [SerializeField] TMP_InputField last_name;
    [SerializeField] TMP_Dropdown mm;
    [SerializeField] TMP_Dropdown dd;
    [SerializeField] TMP_Dropdown yy;
    [SerializeField] TMP_InputField user_name;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField nick_name;
    [SerializeField] TMP_InputField wallet;
    [SerializeField] Toggle genderId;
   

    [SerializeField] TMP_Text errorMessageText;

    [SerializeField] RegisterData userData;
    [SerializeField] RegisterStatus registerStatus;

    [SerializeField] string DOB;

    [SerializeField] MainMenu g_RegisterPanel;
    void Start()
    {
        
    }
    public void OnSubmit()
    {
        
        DOB = yy.value + 1970 + "-" + mm.value+1 +"-"+ dd.value+1 ;
        Debug.Log(first_name.text +" "+ last_name.text);
        Debug.Log(DOB);

        //InitializeData();
        InitializeData();
        StartCoroutine(RegisterUser_Coroutine());
    }
   
    IEnumerator RegisterUser_Coroutine()
    {
        string uri = "https://apiplatzeeland.platzees.io/api/register";
      
        var json =JsonUtility.ToJson(userData);
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
            registerStatus = JsonUtility.FromJson<RegisterStatus>(res);
            if(registerStatus.body.code == "1")
            {
                g_RegisterPanel.onRegisterBtn();

            }
            else
            {
                string errorMessage = res.Split(":")[5].Replace('"', ' ').Replace("}", " ");
                errorMessageText.color = Color.red;
                errorMessageText.text = errorMessage;
            }
        }

        
        
    }
    public class PostResult
    {
        public string success { get; set; }
    }
    void InitializeData()
    {
       
        userData.languageId = 1;
        userData.name = first_name.text;
        userData.last_name = last_name.text;
        userData.date_birth = DOB;
        userData.user_name = user_name.text;
        userData.password = password.text;
        userData.email = email.text;
        userData.nick_name = first_name.text+user_name+last_name;
        userData.wallet = first_name.text + DOB + last_name+ user_name;
        userData.genderId = genderId.isOn ? "1" : "2";

        /* form.AddField("languageId", 1);
         form.AddField("name", "Priyanshu");
         form.AddField("last_name", "Sahu");
         form.AddField("date_birth", "2002-09-02");
         form.AddField("user_name", "Platzee6");
         form.AddField("password", "Platzee6");
         form.AddField("email", "Priyanshu11223@gmail.com");
         form.AddField("nick_name", "Priyanshu231");
         form.AddField("wallet", "xoosoaaskdsakdkasok");
         form.AddField("genderId", "1");*/
    }
}

[System.Serializable]
class RegisterStatus
{
    public string error;
    public string status;
    public RegisterBody body;
}
[System.Serializable]
class RegisterBody
{
    public string code;
    public RegisterbodyData registerbodyData;
}
[System.Serializable]
class RegisterbodyData
{
    public int languageId;
    public string name;
    public string last_name;
    public string date_birth;
    public string user_name;
    public string password;
    public string email;
    public string nick_name;
    public string wallet;
    public string genderId ;
}

[System.Serializable]
public class RegisterData
{
    public int languageId = 1;
    public string token;
    public string name;
    public string last_name;
    public string date_birth;
    public string user_name;
    public string password;
    public string email;
    public string nick_name;
    public string wallet;
    public string genderId = "1";
}