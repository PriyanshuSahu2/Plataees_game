using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class ResetPassword : MonoBehaviour
{
    
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_Text errorMessageText;

    private Data data = new Data();
    private ResetData ResetData = new ResetData();
    
    public void onResetBtn()
    {
        data.email = email.text;
        StartCoroutine(LoginUser_Coroutine());
    }
    IEnumerator LoginUser_Coroutine()
    {
        string uri = "https://apiplatzeeland.platzees.io/api/resetpass";

        var json = JsonUtility.ToJson(data);
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
            ResetData = JsonUtility.FromJson<ResetData>(res);
            if (ResetData.body.code == "1")
            {
                errorMessageText.color = Color.green;
                errorMessageText.text = ResetData.body.data;
            }
            else
            {
                
                errorMessageText.color = Color.red;
                errorMessageText.text = ResetData.body.data;
            }
            Debug.Log(res);
        }
    }
}
[System.Serializable]
 public class Data
{
    public string email;

}

[System.Serializable]
public class ResetData
{
    public string error;
    public string status;
    public BodyData body;
}

[System.Serializable]
public class BodyData
{
    public string code;
    public string data;
}