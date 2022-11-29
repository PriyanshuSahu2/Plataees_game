using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerInfo",menuName ="PlayerInfo")]
public class PlayerData :ScriptableObject
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

        Debug.Log(name + " " + last_name);
    }

}
