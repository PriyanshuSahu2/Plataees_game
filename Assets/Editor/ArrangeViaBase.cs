using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ArrangeViaBase : EditorWindow
{

    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] List<GameObject> replaceGameObjects = new List<GameObject>();
    [SerializeField] Vector2 scrollPos;
    [MenuItem("Window/Platzees/ArrangeViaBase")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ArrangeViaBase>("ArrangeViaBase");
    }
    string childObjectName;
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("How Many Houses You Want To Replace");
        childObjectName = EditorGUILayout.TextField("Object Name: ", childObjectName);
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("ListAll"))
        {
            GameObject[] parentObjects = GameObject.FindGameObjectsWithTag("House");
            GameObject[] replaceParentObject = GameObject.FindGameObjectsWithTag("ReplaceWith");
            

            foreach (GameObject parent in parentObjects)
            {
                Transform parentTransform = parent.transform;

                Transform childTransform = parentTransform.Find(childObjectName);
                if (childTransform != null)
                {
                    // Child object with the specific name found
                    gameObjects.Add(parent);
                    
                }
            }
            foreach(GameObject parent in replaceParentObject)
            {
                Transform parentTransform = parent.transform;

                Transform childTransform = parentTransform.Find(childObjectName);
                if (childTransform != null)
                {
                    // Child object with the specific name found
                    replaceGameObjects.Add(parent);
                    
                }
            }

        }
        if (GUILayout.Button("Replace"))
        {
            if (gameObjects.Count < replaceGameObjects.Count)
            {
                Replace(gameObjects.Count);
            }
            else
            {
                Replace(replaceGameObjects.Count);
            }
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
            for (int i = 0; i < size; i++)
            {
                replaceGameObjects[i].transform.position = gameObjects[i].transform.position;
                replaceGameObjects[i].transform.rotation = gameObjects[i].transform.rotation;
                
                
            }
            for (int i = 0; i < size; i++)
            {
                DestroyImmediate(gameObjects[i]);
            }

        }
    }
}

