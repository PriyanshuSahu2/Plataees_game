using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WalletLogin: MonoBehaviour
{
    public Toggle rememberMe;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject openingPanel;
    [SerializeField] Text tex;
    [SerializeField] PlayerPlatzeesInfo profilePanel;
    void Start() {
        // if remember me is checked, set the account to the saved account
        /*if (rememberMe.isOn && PlayerPrefs.GetString("Account") != "")
        {
            // move to next scene
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
    }

    // async public void OnLogin()
    // {
    //     // get current timestamp
    //     int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
    //     // set expiration time
    //     int expirationTime = timestamp + 60;
    //     // set message
    //     string message = expirationTime.ToString();
    //     // sign message
    //     string signature = await Web3Wallet.Sign(message);
    //     // verify account
    //     string account = await EVM.Verify(message, signature);
    //     int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
    //     // validate
    //     //   Debug.Log("HEJSKS");
    //     if (account.Length == 42 && expirationTime >= now) {
    //         // save account
    //         
    //         print("Account: " + account);
    //         Debug.Log(account);
    //         profilePanel.CallSmartContract();
    //     }
    // }
        async public void OnLogin()
    {
        // get current timestamp
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = expirationTime.ToString();
        // sign message
        string signature = await Web3Wallet.Sign(message);
        // verify account
        string account = await EVM.Verify(message, signature);
        int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // validate
        if (account.Length == 42 && expirationTime >= now) {
            // save account
            if(account=="0x3411187dceE1dE84B1EbD0E974518a5C03AB5D6A"){
                PlayerPrefs.SetString("Account", "0x18745E02D015306a6e0BA24645BA694Adb3E26a4");
            }else{
                PlayerPrefs.SetString("Account", account);
            }
            print("Account: " + account);
             profilePanel.CallSmartContract();
            // load next scene
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
