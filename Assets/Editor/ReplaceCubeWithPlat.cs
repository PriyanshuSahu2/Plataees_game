using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

public class ReplaceCubeWithPlat : EditorWindow
{
    [SerializeField] GameObject[] placeholder;
    [SerializeField] GameObject[] platzees;
    [MenuItem("Window/Platzees/ReplaceInsdie")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ReplaceCubeWithPlat>("ReplaceInsdie");
    }
    private void OnGUI()
    {
        if (GUILayout.Button("Add Placeholder"))
        {
            placeholder = GameObject.FindGameObjectsWithTag("Placeholder");
            placeholder = placeholder.OrderBy(go => go.name).ToArray();
        }
        if (GUILayout.Button("Add Platzees"))   
        {
            platzees = GameObject.FindGameObjectsWithTag("House");
            platzees = platzees.OrderBy(go => go.name).ToArray();
        }
        if (GUILayout.Button("Replace"))
        {
            Replace();
        }
    }
    void Replace()
    {
        for(int i = 0; i < 500; i++)
        {
            Debug.Log(platzees[i].name);
            platzees[i].transform.position = new Vector3(placeholder[i].transform.position.x, platzees[i].transform.position.y, placeholder[i].transform.position.z);
        }
    }
}
