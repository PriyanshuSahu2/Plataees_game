using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] Image selected;
    [SerializeField] Image graphics;
    [SerializeField] Image sound;
    [SerializeField] Image controls;

    [Header("Parent")]
    [SerializeField] GameObject Graphics;
    [SerializeField] GameObject Sounds;
    [SerializeField] GameObject Controls;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        selected = graphics.GetComponent<Image>();
        selected.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGraphicsBtn()
    {
        Sounds.SetActive(false);
        Controls.SetActive(false);
        Graphics.SetActive(true);
    }
    public void OnSoundBtn()
    {
        Sounds.SetActive(true);
        Controls.SetActive(false);
        Graphics.SetActive(false);
    }
    public void OnControlsBtn()
    {
        Sounds.SetActive(false);
        Controls.SetActive(true);
        Graphics.SetActive(false);
    }
    public void onClicked(Image gb)
    {
        selected = gb;
        graphics.fillAmount = 0;
        sound.fillAmount = 0;
        controls.fillAmount = 0;
        selected.fillAmount = 1;

    }
    public void onHover(Image img)
    {
        img.fillAmount = 1;
    }
    public void unHover(Image img)
    {
        Debug.Log("uNHOVER");
        if(img == selected)
        {
            return;
        }
        img.fillAmount = 0;
    }
}
