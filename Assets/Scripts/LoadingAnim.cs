using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] gb;
     float timer=3f;
    
    int i = -1;
    [SerializeField]  float time;
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (i == 2)
            {
                i = -1;
                foreach(GameObject gab in gb)
                {
                    gab.SetActive(false);
                }

            }
            else
            {
                i++;
                gb[i].SetActive(true);
               
            }
            timer = time;

        }
        else
        {
            timer -= Time.deltaTime;
        }

        
    }
}
