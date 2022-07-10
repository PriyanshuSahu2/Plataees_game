using UnityEditor;
using UnityEngine;
using System.IO;

public class LevelGenerator : EditorWindow
{
    public Texture2D map;
    [SerializeField] Color color;
    [SerializeField] int size;
    [SerializeField] GameObject[] gamobjects;
    [SerializeField] Vector3 pos = new Vector3(2000,0,1000);
    [SerializeField] Vector2 scrollPos;
    private string path = "No Path";
    int i = 0;
    string[] info;
    [MenuItem("Window/Level Generator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelGenerator>("LevelGenerator");
    }
    private void OnGUI()
    {
        map = EditorGUILayout.ObjectField(map,typeof(Texture2D),false) as Texture2D;
        color = EditorGUILayout.ColorField(color);
        Automatic();
        if (GUILayout.Button("Generate Level"))
        {
            GenerateLevel();
        }
        
    }
    void GenerateLevel()
    {
        for(int x =0;x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                
                GenerateTile(x,y);
                
            }
        }
    }
    int posx = 2000;
    int posz = -1000;
    void GenerateTile(int x,int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        pos = new Vector3(posx-x*43, 0,posz+y*43);
        Debug.Log(pos);
        if (pixelColor.a == 0)
        {
            return;
        }
        Instantiate(gamobjects[i], pos, Quaternion.identity);
        i++;
       
    }


    void Automatic()
    {
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Path");
        path = GUILayout.TextField(path);
        if (GUILayout.Button("Select FOlder"))
        {
            path = EditorUtility.OpenFolderPanel("Path", Application.dataPath, "");
            info = Directory.GetFiles(path, "*.Fbx");
            gamobjects = new GameObject[info.Length];
        }
        GUILayout.EndHorizontal();


        
        GUILayout.BeginHorizontal();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();


        for (int i = 0; i < gamobjects.Length; i++)
        {
            string t = info[i].Replace("D:/Unity Projects/Plataees_game/", "");
            Object g = AssetDatabase.LoadAssetAtPath(t.Replace("\\", "/"), typeof(GameObject));
            gamobjects[i] = EditorGUILayout.ObjectField(g, typeof(GameObject), true) as GameObject;

        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
    private void OnEnable()
    {
        gamobjects = new GameObject[0]; 
    }
}
