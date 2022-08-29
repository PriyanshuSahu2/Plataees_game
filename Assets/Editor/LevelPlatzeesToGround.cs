using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class LevelPlatzeesToGround : EditorWindow
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] GameObject[] tempGameObjects;
    private string ObjectName = "0.0";

    [SerializeField] float size;
    [MenuItem("Window/Platzees/LevelThePlatzees")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelPlatzeesToGround>("LevelThePlatzees");
    }
    private void OnGUI()
    {
        ObjectName = EditorGUILayout.TextField(ObjectName);
      
        EditorGUILayout.BeginVertical();
        if(GUILayout.Button("Add Houses"))
        {
            size = float.Parse(ObjectName);
            Debug.Log(size);
            gameObjects = GameObject.FindGameObjectsWithTag("Base");
            int i = 0;
            foreach(GameObject gb in gameObjects)
            {
                gb.tag = "Untagged";
                gb.transform.parent.gameObject.transform.position = new Vector3(gb.transform.parent.gameObject.transform.position.x,100+size, gb.transform.parent.gameObject.transform.position.z);
               // gameObjects[i] = EditorGUILayout.ObjectField(gameObjects[i], typeof(GameObject), true) as GameObject;
                
                i++;

            }
        }
        EditorGUILayout.EndVertical();
    }
}
