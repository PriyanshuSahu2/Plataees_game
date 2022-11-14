using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
public class PlatzeesName :EditorWindow
{
    [SerializeField] GameObject[] gamobjects;
    [SerializeField] GameObject canvas;
    [MenuItem("Window/Platzees/AddName")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PlatzeesName>("AddName");
    }
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Select"))
        {
            gamobjects = GameObject.FindGameObjectsWithTag("House");
        }
        if (GUILayout.Button("Confirm"))
        {
            for(int i = 0; i < gamobjects.Length; i++)
            {
                GameObject g = Instantiate(canvas, new Vector3(0, 0, 0), Quaternion.identity, gamobjects[i].transform);
                g.GetComponent<RectTransform>().localPosition = canvas.GetComponent<RectTransform>().localPosition;
                g.GetComponent<RectTransform>().localRotation = canvas.GetComponent<RectTransform>().rotation;
                string name = gamobjects[i].name;
                if (name.Length == 1)
                {
                    g.GetComponentInChildren<TMP_Text>().text = "<i>#</i>" + "00" + name;
                }else if (name.Length == 2)
                {
                    g.GetComponentInChildren<TMP_Text>().text = "<i>#</i>" + "0" + name;
                }
                else
                {
                    g.GetComponentInChildren<TMP_Text>().text = "<i>#</i>" + name;
                }
                
            }
        }
        EditorGUILayout.EndHorizontal();
    }
}
