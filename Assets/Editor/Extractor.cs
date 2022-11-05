using UnityEditor;
using UnityEngine;
using System.IO;
public class Extractor : EditorWindow
{
    [SerializeField] string currentSettings;
    [SerializeField] int size;
    [SerializeField] GameObject[] gamobjects;
    [SerializeField] Vector3[] location;
    [SerializeField] GameObject gb;
    [SerializeField] bool isManual = false;
    [SerializeField] bool isAutomatic = false;
    [SerializeField] Object[] k;
    [SerializeField] Vector2 scrollPos;
    private DefaultAsset targetFolder = null;

    [MenuItem("Window/Platzees/Extractor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Extractor>("Extractor");

    }
    private void OnGUI()
    {

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Using Folder"))
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

        GUILayout.Label(currentSettings, centeredStyle);
        Automatic();
        if (GUILayout.Button("Extract"))
        {

            for (int i = 0; i < gamobjects.Length; i++)
            {
                string t = info[i].Replace("F:/Unity Projects/Plataees_game/", "");
                Object g = AssetDatabase.LoadAssetAtPath(t.Replace("\\", "/"), typeof(GameObject));
                var tex = AssetImporter.GetAtPath(t) as ModelImporter;
                tex.materialLocation = ModelImporterMaterialLocation.External;
                tex.materialName = ModelImporterMaterialName.BasedOnModelNameAndMaterialName;
              //  tex.ExtractTextures("Assets/All Houese/Textures/" + g.name);
                // Debug.Log(tex.ExtractTextures("Assets/All Houese/Textures/"+g.name));
                gamobjects[i] = EditorGUILayout.ObjectField(g, typeof(GameObject), true) as GameObject;

            }
        }
    }
    private void OnEnable()
    {
        gamobjects = new GameObject[0];
        location = new Vector3[0];
    }

    private string path = "No Path";
    int i = 0;
    string[] info;
    void Automatic()
    {
        
        GUILayout.BeginHorizontal();

        GUILayout.Label("Path");
        path = GUILayout.TextField(path);
        if (GUILayout.Button("Select FOlder"))
        {
            path = EditorUtility.OpenFolderPanel("Path", Application.dataPath, "");
            info = Directory.GetFiles(path, "*.Fbx");
            location = new Vector3[info.Length];
            gamobjects = new GameObject[info.Length];
        }
        GUILayout.EndHorizontal();



        GUILayout.BeginHorizontal();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();


        EditorGUILayout.EndScrollView();
      
        EditorGUILayout.EndVertical();


        GUILayout.EndHorizontal();
    }
}
