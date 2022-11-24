using UnityEngine;
using TMPro;
public class PlatzeeNames : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public void setText(string name)
    {
        text.text = "PLatzee #" + name;
    }
   
}
