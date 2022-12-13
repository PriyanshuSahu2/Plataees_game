using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterCustomization : MonoBehaviour
{
    // Start is called before the first frame update
     Material skinMaterial;
     Material hairMaterial;
     Material shirtMaterial;
     Material pantMaterial;
     Material eyeMaterial;


    [Header("Male  ")]
    [SerializeField] GameObject MaleCharacter;
    [SerializeField] Material MskinMaterial;
    [SerializeField] Material MhairMaterial;
    [SerializeField] Material MshirtMaterial;
    [SerializeField] Material MpantMaterial;
    [SerializeField] Material MeyeMaterial;
    [Header("Female ")]
    [SerializeField] GameObject FemaleCharacter;
    [SerializeField] Material FskinMaterial;
    [SerializeField] Material FhairMaterial;
    [SerializeField] Material FshirtMaterial;
    [SerializeField] Material FpantMaterial;
    [SerializeField] Material FeyeMaterial;

    [SerializeField] GameObject mainCam;

    [SerializeField] GameObject[] cam;

    [SerializeField] Toggle[] selectedGameObject;
    [SerializeField] GameObject[] colorPanels;
    GameObject targetPos;
    [SerializeField] GameObject currentPos;

    
    void Start()
    {
 
        skinMaterial.color =convertStringToColor(PlayerPrefs.GetString("SkinColor",skinMaterial.color.ToString()));
        hairMaterial.color =convertStringToColor(PlayerPrefs.GetString("HairColor", hairMaterial.color.ToString()));
        shirtMaterial.color =convertStringToColor(PlayerPrefs.GetString("ShirtColor", shirtMaterial.color.ToString()));
        pantMaterial.color =convertStringToColor(PlayerPrefs.GetString("PantColor", pantMaterial.color.ToString()));
        eyeMaterial.color =convertStringToColor(PlayerPrefs.GetString("EyeColor", eyeMaterial.color.ToString()));
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetString("PlayerGender") == "MPlayer")
        {
            skinMaterial = MskinMaterial;
            hairMaterial = MhairMaterial;
            pantMaterial = MpantMaterial;
            eyeMaterial = MeyeMaterial;
            shirtMaterial = MshirtMaterial;
            MaleCharacter.SetActive(true);
            FemaleCharacter.SetActive(false);

        }
        else
        {
            skinMaterial = FskinMaterial;
            hairMaterial =FhairMaterial;
            pantMaterial = FpantMaterial;
            eyeMaterial =FeyeMaterial;
            shirtMaterial = FshirtMaterial;
            MaleCharacter.SetActive(false);
            FemaleCharacter.SetActive(true);
        }
    }
    public Color convertStringToColor(string col)
    {
       col =  col.Replace("RGBA(", "");
        col = col.Replace(")", "");
        var colorValue = col.Split(",");
        Color color = new Color();
        color.r = float.Parse(colorValue[0]) ;
        color.g = float.Parse(colorValue[1]) ;
        color.b = float.Parse(colorValue[2]) ;
        color.a = 1f ;
        return color;
    }

    public void skinchangeColor()
    {


        GameObject btn = EventSystem.current.currentSelectedGameObject;
        // changeCam(skinCam);
            
        skinMaterial.color = btn.GetComponent<Button>().colors.normalColor;
     
        PlayerPrefs.SetString("SkinColor", ColorUtility.ToHtmlStringRGBA(skinMaterial.color));
    }
    public void hairchangeColor()
    {


        GameObject btn = EventSystem.current.currentSelectedGameObject;
        // changeCam(hairCam);
         hairMaterial.color = btn.GetComponent<Button>().colors.normalColor;
        PlayerPrefs.SetString("HairColor", ColorUtility.ToHtmlStringRGBA(skinMaterial.color));
    }
    public void shirtchangeColor()
    {

        GameObject btn = EventSystem.current.currentSelectedGameObject;
       // changeCam(shirtCam);
        shirtMaterial.color = btn.GetComponent<Button>().colors.normalColor;
        PlayerPrefs.SetString("ShirtColor", ColorUtility.ToHtmlStringRGBA(skinMaterial.color));

    }
    public void pantchangeColor()
    {
        

        GameObject btn = EventSystem.current.currentSelectedGameObject;
       // changeCam(pantCam);
        pantMaterial.color = btn.GetComponent<Button>().colors.normalColor;
        PlayerPrefs.SetString("PantColor", ColorUtility.ToHtmlStringRGBA(skinMaterial.color));

    }
    public void eyechangeColor()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
       // changeCam(eyeCam);
        eyeMaterial.color = btn.GetComponent<Button>().colors.normalColor;
        PlayerPrefs.SetString("EyeColor", ColorUtility.ToHtmlStringRGBA(skinMaterial.color));

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
