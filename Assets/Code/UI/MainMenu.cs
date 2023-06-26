using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameplaySceneName;

    /// <summary>
    /// Called from UnityEvents
    /// </summary>
    public void LoadGameplay()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }
}