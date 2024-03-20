using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }

}
