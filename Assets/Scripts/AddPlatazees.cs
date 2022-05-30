using UnityEditor;
using UnityEngine;
using System.IO;

public class AddPlatazees : EditorWindow
{
    [SerializeField] string currentSettings;
    [SerializeField] int size;
    [SerializeField] GameObject[] gamobjects;
    [SerializeField] Vector3[] location;
    [SerializeField] GameObject gb;
    [SerializeField] bool isManual =false;
    [SerializeField] bool isAutomatic =false;

    private DefaultAsset targetFolder = null;


    [MenuItem("Window/Platzees/Add Platazees")]
   
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<AddPlatazees>("Add");
    }
    private void OnGUI()
    {
        
        EditorGUILayout.BeginHorizontal();
  
        if(GUILayout.Button("Using Folder"))
        {
            currentSettings = "Using Folder";
            isManual = false;
            isAutomatic = true;
        }
        
        if (GUILayout.Button("Manually Add"))
        {
            isManual = true;
            isAutomatic = false;
            currentSettings = "Manually Add";
        }
        EditorGUILayout.EndHorizontal();
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;

        GUILayout.Label(currentSettings,centeredStyle);
        if (isManual)
        {
            Manually();
        }
        if (isAutomatic)
        {
            Automatic();
        }
        if (GUILayout.Button("Add"))
        {
            Add();
        }
        
    }
    private void OnEnable()
    {
        gamobjects = new GameObject[0];
        location = new Vector3[0];
    }
    void Manually()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("How Many Houses You Want To Replace");
        size = EditorGUILayout.IntField(size);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Confirm"))
        {
            gamobjects = new GameObject[size];
            location = new Vector3[size];
        }
       
        GUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < gamobjects.Length; i++)
        {
            gamobjects[i] = EditorGUILayout.ObjectField(gamobjects[i], typeof(GameObject), true) as GameObject;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < location.Length; i++)
        {

            location[i] = EditorGUILayout.Vector3Field("",location[i]);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

    }
    private string path ="No Path";
    int i = 0;
    void Automatic()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Path");
        path = GUILayout.TextField(path);
       if(GUILayout.Button("Select FOlder"))
        {
            path = EditorUtility.OpenFolderPanel("Path", Application.dataPath, "");


        }
        GUILayout.EndHorizontal();
        var info = Resources.LoadAll("Models");
       
        gamobjects = new GameObject[info.Length];
        GUILayout.BeginVertical();
        Debug.Log(info.Length);
        foreach (GameObject gb in info)
        {
            Debug.Log(i);
            gamobjects[i] = EditorGUILayout.ObjectField(gb, typeof(GameObject), true) as GameObject;
            i++;
        }
        GUILayout.EndVertical();
    }
    void Add()
    {
        for (int i = 0; i < gamobjects.Length; i++)
        {
            GameObject c = Instantiate(gamobjects[i], location[i],Quaternion.identity);
            c.name = c.name.Replace("(Clone)", "");
        }
    }
}
