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
        foreach (GameObject gb in gameObjects)
        {

            if (Physics.Raycast(gb.transform.position, gb.transform.TransformDirection(Vector3.forward), 86f))
            {
                Debug.DrawRay(gb.transform.position, gb.transform.TransformDirection(Vector3.forward) * 86f);
                Debug.Log(gb.name);
            }

        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("Arrange"))
        {
            foreach (GameObject gb in gameObjects)
            {

                if (Physics.Raycast(gb.transform.position, gb.transform.TransformDirection(Vector3.forward), 84f))
                {
                    gb.transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                    Debug.Log(gb);
                }
                Debug.DrawRay(gb.transform.position, gb.transform.TransformDirection(Vector3.forward) * 86f);
            }
        }
    }
}
