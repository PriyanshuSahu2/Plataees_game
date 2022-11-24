using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] List<GameObject> navigationItem = new List<GameObject>();
    [SerializeField] List<GameObject> navigationItemLogin = new List<GameObject>();
    [SerializeField] List<GameObject> navigationItemSignUp = new List<GameObject>();
    [SerializeField] List<GameObject> navigationItemSetting = new List<GameObject>();
    [SerializeField] List<GameObject> navigationItemStart = new List<GameObject>();

    [Tooltip("Login")]
    [SerializeField] GameObject Login;
    [SerializeField] GameObject SignUp;
    [SerializeField] GameObject Setting;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject Customization;
    EventSystem eventSystem;

    int i = 0;
    private void Start()
    {
        eventSystem = EventSystem.current;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Initialize();
            i = navigationItem.IndexOf(eventSystem.currentSelectedGameObject);
            i++;
            if ( i == navigationItem.Count)
            {
                i = 0;
            }
            eventSystem.SetSelectedGameObject(navigationItem[i]);
        }
    }
    void Initialize()
    {
        if (Login.activeSelf)
        {
            navigationItem = navigationItemLogin;
        }else if (SignUp.activeSelf)
        {
            navigationItem = navigationItemSignUp;
        }else if (StartMenu.activeSelf)
        {
            navigationItem = navigationItemStart;
        }else if (Setting.activeSelf)
        {
            navigationItem = navigationItemSetting;
        }
    }

    
}
