using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DropDownOptions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown YY;
    [SerializeField] TMP_Dropdown DD;
    [SerializeField]List<string> YOptions = new List<string>();
    [SerializeField]List<string> MOptions = new List<string>();
    private void Start()
    {
        for(int i = 1; i <= 30; i++)
        {
            MOptions.Add(i.ToString());
        }
        for (int i = 1970; i < 2023; i++)
        {
            YOptions.Add(i.ToString());
        }
        DD.ClearOptions();
        YY.ClearOptions();
        YY.AddOptions(YOptions);
        DD.AddOptions(MOptions);
    }
}
