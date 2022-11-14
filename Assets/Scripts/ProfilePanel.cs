using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ProfilePanel : MonoBehaviour
{
    private const string V = " ";
    EventSystem eventSystem;
    [SerializeField] TMP_InputField name;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] Toggle[] genders;
    [SerializeField] GameObject[] genderImages;
    [SerializeField] UpdateData updateData ;
    private void Start()
    {
        eventSystem = EventSystem.current;
    }
    public void SetValue()
    {
        
        name.text = PlayerData.name+" "+ PlayerData.last_name;
        email.text = PlayerData.email;
        username.text = PlayerData.user_name;
        if(PlayerData.genderId == "1")
        {
            genders[0].isOn = true;
            genders[1].isOn = false;
            genderImages[0].SetActive(true);
            genderImages[1].SetActive(false);
        }
        else
        {
            genders[0].isOn = false;
            genders[1].isOn = true;
            genderImages[0].SetActive(false);
            genderImages[1].SetActive(true);
        }
    }
   public void changeGender(int g)
    {
        if (g==1)
        {
            genderImages[0].SetActive(true);
            genderImages[1].SetActive(false);
        }
        else
        {
            genderImages[0].SetActive(false);
            genderImages[1].SetActive(true);
        }
    }
    public void MakeInteractable(TMP_InputField panel)
    {
        panel.interactable = true;
        eventSystem.SetSelectedGameObject(panel.gameObject);
    }
   public void OnSubmit()
    {
        updateData = new UpdateData();
        InitializeData();
        StartCoroutine(PlayerUpdate_Coroutine());
    }
    IEnumerator PlayerUpdate_Coroutine()
    {
        string uri = "https://apiplatzeeland.platzees.io/api/update";
        var json =JsonUtility.ToJson(updateData);
        UnityWebRequest req = new UnityWebRequest(uri, "PUT");
        byte[] rawData = System.Text.Encoding.UTF8.GetBytes(json);
        req.uploadHandler = new UploadHandlerRaw(rawData);
        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
       req.SetRequestHeader("Authorization", "Bearer "+PlayerPrefs.GetString("Token"));
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(req.error);
        }
        else
        {
           string res = req.downloadHandler.text;
           Debug.Log(res);
        }
    }
    void InitializeData()
    {
      
        updateData.name = name.text.Split(" ")[0];
        updateData.last_name = name.text.Split(" ")[1];
        updateData.email = email.text;
        updateData.user_name = username.text;
        updateData.password = password.text;
        if (genders[0].isOn)
        {
            updateData.genderId = "1";
        }
        else
        {
            updateData.genderId = "0";
        }
    }
}
[System.Serializable]
class UpdateData
{
    public string name;
    public string last_name;
    public string user_name;
    public string password;
    public string email;
    public string genderId;
}
