using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Colorizer : EditorWindow
{
    [SerializeField] Material mb;
    [SerializeField] Vector2 scrollPos;
    [SerializeField] Object Gb;
    [SerializeField] Material[] gamobjects ;
    [SerializeField] Object[] objects = new Object[100];
    Color col;
    private string path = "No Path";
   
    string[] info;
    [MenuItem("Window/Platzaees")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Colorizer>("Colorizer");
    }
    private void OnEnable()
    {
        gamobjects = new Material[0];
    }
    private void OnGUI()
    {
   
        if (GUILayout.Button("Select Materials"))
        {
            int i = 0;
            foreach (Object o in Selection.objects)
            {
    
                objects[i] = o;
                i++;
            }
            gamobjects = new Material[Selection.objects.Length];

        }
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();

        for (int i = 0; i < gamobjects.Length; i++)
        {
            gamobjects[i] = EditorGUILayout.ObjectField(objects[i], typeof(Material), true) as Material;
        }

        if (GUILayout.Button("Emitt"))
        {
            foreach(Material mb in gamobjects)
            {
                string temp = mb.name;
                temp = temp.Split(" ")[1];
                if (temp.Contains("."))
                {
                    temp = temp.Split(".")[0];
                }
                 if(ColorUtility.TryParseHtmlString("#"+temp, out col))
                {
                    Debug.Log(col);
                    mb.color = col;
                    mb.EnableKeyword("_EMISSION");
                    mb.SetColor("_EmissionColor", col);
                }

                
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
    }
}
