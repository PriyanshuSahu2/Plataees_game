using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;
public class PlatazeesReplace : EditorWindow
{
    [SerializeField] int size;
    public string temp;
    [SerializeField] GameObject[] gamobjects;
    [SerializeField] GameObject[] replaceWith;
    [SerializeField] GameObject gb;
    [SerializeField] Vector2 scrollPos;
    private string path = "No Path";
    int i = 0;
    string[] info;
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
        GUILayout.BeginHorizontal();

        GUILayout.Label("Path");
        path = GUILayout.TextField(path);
        if (GUILayout.Button("Select FOlder"))
        {
            path = EditorUtility.OpenFolderPanel("Path", Application.dataPath, "");
            info = Directory.GetFiles(path, "*.Fbx");
            replaceWith = new GameObject[info.Length];
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Confirm"))
        {
            gamobjects = GameObject.FindGameObjectsWithTag("House");
            gamobjects = gamobjects.OrderBy(go => go.name).ToArray();
        }
        EditorGUILayout.BeginHorizontal();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < gamobjects.Length; i++)
        {
            
            gamobjects[i] = EditorGUILayout.ObjectField(gamobjects[i], typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < replaceWith.Length; i++)
        {
            string t = info[i].Replace("D:/Unity Projects/Plataees_game/", "");
            Object g = AssetDatabase.LoadAssetAtPath(t.Replace("\\", "/"), typeof(GameObject));
            replaceWith[i] = EditorGUILayout.ObjectField(g, typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
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
