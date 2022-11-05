using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HoverButton : MonoBehaviour
{

    

    public void OnPointerEnter(RectTransform image)
    {
        image.GetComponent<Animator>().Play("Hover");
    }
    public void OnPointerExit(RectTransform image)
    {
        image.GetComponent<Animator>().Play("HoverOff");
    }

}
