using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ArrangeHouses : EditorWindow
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Object Gb;
    [SerializeField] Vector2 scrollPos;
    [MenuItem("Window/Platzees/Arrange")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ArrangeHouses>("Arrange");
    }
    private void OnGUI()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("House");
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();
        
        foreach (Object gb in gameObjects)
        {
            GameObject k = (GameObject)gb;
            EditorGUILayout.LabelField(k.name);
            Gb = EditorGUILayout.ObjectField(gb, typeof(object), true);
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("Arrange"))
        {
            foreach (GameObject gb in gameObjects)
            {
               
                if (Physics.Raycast(gb.transform.position, gb.transform.TransformDirection(Vector3.right), Mathf.Infinity))
                {
                    
                    Debug.Log(gb.name);
                }
                Debug.DrawRay(gb.transform.position, gb.transform.position * 86f);
            }
        }
    }
}
