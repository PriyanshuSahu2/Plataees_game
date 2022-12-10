using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Axis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject xAxis;
    [SerializeField] GameObject yAxis;
    [SerializeField] GameObject player;
    [SerializeField] float x = 3.35f;
    [SerializeField] float y = 3.17f;
    [SerializeField] Image image; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{player.transform.position.x - xAxis.transform.position.x} , {player.transform.position.z - yAxis.transform.position.z}");
        image.rectTransform.anchoredPosition = new Vector2(-(player.transform.position.x - xAxis.transform.position.x) /x, -(player.transform.position.z - yAxis.transform.position.z) / y);
    }
}
