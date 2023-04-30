using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
    public void LoadNextScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }
    

}
