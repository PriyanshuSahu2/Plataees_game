using UnityEditor;
using UnityEngine;

public class PlatazeesReplace : EditorWindow
{
    [SerializeField] int size;
    public string temp;
    [SerializeField] GameObject[] gamobjects;
    [SerializeField] GameObject[] replaceWith;
    [SerializeField] GameObject gb;
    [MenuItem("Window/Platzees/Replace")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PlatazeesReplace>("Replace");
    }
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("How Many Houses You Want To Replace");
        temp =EditorGUILayout.TextField("Object Name: ", temp);
        int.TryParse(temp,out size);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
     
        if (GUILayout.Button("Confirm"))
        {
            gamobjects = new GameObject[size];
            replaceWith = new GameObject[size];
        }
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < gamobjects.Length; i++)
        {
            Debug.Log("Ekek");
            gamobjects[i] = EditorGUILayout.ObjectField(gamobjects[i], typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < replaceWith.Length; i++)
        {
            replaceWith[i] = EditorGUILayout.ObjectField(replaceWith[i], typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        if (GUILayout.Button("Replace"))
        {
            Replace();
        }
    }
    private void OnEnable()
    {
        gamobjects = new GameObject[0];
        replaceWith = new GameObject[0];
    }

    void Replace()
    {
        for (int i = 0; i < gamobjects.Length; i++)
        {
           GameObject c =  Instantiate(replaceWith[i], gamobjects[i].transform.position, gamobjects[i].transform.rotation);
            c.name = c.name.Replace("(Clone)","");
            DestroyImmediate(gamobjects[i]);
        }
    }
}
