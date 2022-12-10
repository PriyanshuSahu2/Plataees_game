using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string path = @"C:\Users\sahup\Desktop\New folder";
    [SerializeField]
    
    int size = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            path += "screenshot ";
            path += System.Guid.NewGuid().ToString()+".png";
            ScreenCapture.CaptureScreenshot(path, size);
        }
    }
}
