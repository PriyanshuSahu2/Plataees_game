using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterCustomization : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField] Material skinMaterial;
    [SerializeField] Material hairMaterial;
    [SerializeField] Material shirtMaterial;
    [SerializeField] Material pantMaterial;
    [SerializeField] Material eyeMaterial;
    [SerializeField] GameObject mainCam;

    [SerializeField] GameObject[] cam;

    [SerializeField] Toggle[] selectedGameObject;
    [SerializeField] GameObject[] colorPanels;
    GameObject targetPos;
    [SerializeField] GameObject currentPos;
    void Start()
    {
        
    }

    public void skinchangeColor()
    {


        GameObject btn = EventSystem.current.currentSelectedGameObject;
        // changeCam(skinCam);
   
        skinMaterial.color = btn.GetComponent<Button>().colors.normalColor;
    }
    public void hairchangeColor()
    {


        GameObject btn = EventSystem.current.currentSelectedGameObject;
        // changeCam(hairCam);
         hairMaterial.color = btn.GetComponent<Button>().colors.normalColor;
    }
    public void shirtchangeColor()
    {

        GameObject btn = EventSystem.current.currentSelectedGameObject;
       // changeCam(shirtCam);
        shirtMaterial.color = btn.GetComponent<Button>().colors.normalColor;

    }
    public void pantchangeColor()
    {
        

        GameObject btn = EventSystem.current.currentSelectedGameObject;
       // changeCam(pantCam);
        pantMaterial.color = btn.GetComponent<Button>().colors.normalColor;

    }
    public void eyechangeColor()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
       // changeCam(eyeCam);
        eyeMaterial.color = btn.GetComponent<Button>().colors.normalColor;

    }
    public void changeCam(GameObject currCam)
    {
        foreach (GameObject i in cam)
        {
            i.SetActive(false);
        }
        currCam.SetActive(true);
    }
    public void moveCamera()
    {
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, targetPos.transform.position, Time.deltaTime*2);
    }
    bool canMove =false;
    private void Update()
    {
        if (canMove)
        {
            moveCamera();
        }
    }
    public void onSelected()
    {
        canMove = false;
       
        GameObject temp = new GameObject();
        for(int i = 0; i < 5; i++)
        {
            colorPanels[i].SetActive(false);

            if (selectedGameObject[i].isOn)
            {
                targetPos = cam[i];
                canMove = true;
                temp = colorPanels[i];
            }
        }
        if (!canMove)
        {
            Debug.Log("Called");
            targetPos = currentPos;
            canMove = true;
        }
        else
        {
            temp.SetActive(true);
        }
        
    }
}
