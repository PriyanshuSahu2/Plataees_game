using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighlightPlatzees : MonoBehaviour
{
    [SerializeField] GameObject gb;
    [SerializeField] string[] s_plat;
   
    void Start()
    {
        // s_plat = PlayerPlatzeesInfo.myPlatzees;
        StartCoroutine(HighlightPlatzee(s_plat));
    }

    IEnumerator HighlightPlatzee(string[] sPlat)
    {
        foreach(string plat in sPlat)
        {
            gb = GameObject.Find(plat);
            if (gb != null)
            {
                // gb.GetComponentInChildren<TMP_Text>().color = new Color(255, 177, 0, 255);
               foreach(TMP_Text t in gb.GetComponentsInChildren<TMP_Text>())
                {
                    t.color = new Color(255, 177, 0, 255);
                }
            }
            yield return new WaitForBackgroundThread(); 
        }
    }
}
