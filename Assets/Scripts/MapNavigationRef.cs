using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MapNavigationRef : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] DistanceCalculate playerMap;
    [SerializeField] GameObject map;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        map = GameObject.Find("FullMap");
        if (player!=null)
        {

        playerMap = player.GetComponentInChildren<DistanceCalculate>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NavigateMap(TMP_Text address)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            string s = address.text;
            s = s.Split("#")[1];
            
            GameObject currTarget = GameObject.Find(s);
            playerMap.currTarget = currTarget;
            map.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
