using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axis : MonoBehaviour
{
    [SerializeField] GameObject xAxis;
    [SerializeField] GameObject yAxis;
    public GameObject myPlayer;
    [SerializeField] Image image;

    private float levelWidth = 2370.44f;
    private float levelHeight = 2453.12f;
    private float mapWidth = 1058f;
    private float mapHeight = 996f;

    private void Update()
    {
        // Calculate the scale factor for the map
        float xScale = mapWidth / levelWidth;
        float yScale = mapHeight / levelHeight;

        // Calculate the position of the player relative to the map
        float playerX = myPlayer.transform.position.x / levelWidth * mapWidth;
        float playerY = myPlayer.transform.position.z / levelHeight * mapHeight;

        // Set the position of the map icon
        image.rectTransform.anchoredPosition = new Vector2(playerX, playerY);
    }
}
