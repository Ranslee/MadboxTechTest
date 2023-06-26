using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnAwake : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private LoadSceneMode loadMode;
    
    private void Awake()
    {
        SceneManager.LoadScene(sceneName, loadMode);
    }
}
