using UnityEngine;
using TMPro;

public class HoverEffect : MonoBehaviour
{
    
    public void chnageColor(TMP_Text text)
    {
        text.color = Color.white;
        text.fontStyle = FontStyles.Bold;
    }
    public void chnageBack(TMP_Text text)
    {
        text.color = Color.black;
        text.fontStyle = FontStyles.Normal;
    }
}
