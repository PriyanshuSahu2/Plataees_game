using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingLevel : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] Image m_ProgreesBar;
    
    void Start()
    {
      //  StartCoroutine(LoadLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public IEnumerator LoadLevel()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        while (!asyncOperation.isDone)
        {
            m_ProgreesBar.fillAmount = asyncOperation.progress + 0.1f;
            yield return null;
        }
        yield return null;
    }
}
