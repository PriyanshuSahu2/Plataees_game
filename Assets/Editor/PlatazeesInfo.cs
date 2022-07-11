using UnityEditor;
using UnityEngine;

public class PlatazeesInfo : EditorWindow
{
    [SerializeField] Object  Gb;
   [SerializeField] Vector2 scrollPos;
    [SerializeField] GameObject[] objects;

    [MenuItem("Window/Platzees/Infos")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PlatazeesInfo>("Extractor");
        
    }
    private void OnGUI()
    {
        objects = GameObject.FindGameObjectsWithTag("House");
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginHorizontal();
      
        EditorGUILayout.BeginVertical();
        
        foreach (Object gb in objects)
        {
            GameObject k = (GameObject)gb;
            EditorGUILayout.LabelField(k.name);
            Gb = EditorGUILayout.ObjectField(gb, typeof(object), true);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        foreach (Object gb in objects)
        {
            GameObject k = (GameObject)gb;
            EditorGUILayout.Vector3Field("Position", k.transform.position);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        foreach (Object gb in objects)
        {

    
        }
        EditorGUILayout.EndVertical();
       
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("Extract" ,GUILayout.Height(40)))
        {
           
        }
    }
}
