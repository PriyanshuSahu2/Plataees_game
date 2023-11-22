using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ReplaceLastReamining : EditorWindow
{
    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] List<GameObject> replaceGameObjects = new List<GameObject>();
    [SerializeField] Vector2 scrollPos;
    [MenuItem("Window/Platzees/ReplaceRemainingPlatzees")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ReplaceLastReamining>("ReplaceRemainingPlatzees");
    }

    private void OnGUI()
    {

        if (GUILayout.Button("ListAll"))
        {
            GameObject[] parentObjects = GameObject.FindGameObjectsWithTag("House");
            GameObject[] replaceParentObject = GameObject.FindGameObjectsWithTag("ReplaceWith");
            Debug.Log(parentObjects);

            foreach (GameObject parent in parentObjects)
            {
          


                    gameObjects.Add(parent);

                
            }
            foreach (GameObject parent in replaceParentObject)
            {

                replaceGameObjects.Add(parent);
            }

        }
        if (GUILayout.Button("Replace"))
        {
            Replace(Mathf.Min(replaceGameObjects.Count, gameObjects.Count));
        }
        EditorGUILayout.BeginHorizontal();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i] = EditorGUILayout.ObjectField(gameObjects[i], typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < replaceGameObjects.Count; i++) // Changhe to replaceWith.Length
        {
            replaceGameObjects[i] = EditorGUILayout.ObjectField(replaceGameObjects[i], typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();




        void Replace(int size)
        {
            Debug.Log(size);
            for (int i = 0; i < size; i++)
            {
                replaceGameObjects[i].transform.position = gameObjects[i].transform.position;
                replaceGameObjects[i].transform.rotation = gameObjects[i].transform.rotation;
                replaceGameObjects[i].gameObject.tag = "Completed";

            }
            for (int i = 0; i < size; i++)
            {
                DestroyImmediate(gameObjects[i]);
            }

        }
    }
}
