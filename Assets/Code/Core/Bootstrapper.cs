using System.Collections;
using UnityEngine;
using Madbox.CheatConsole;
using UnityEngine.AddressableAssets;

/// <summary>
/// The first script to be created when launching the game, it should be the entry point to everything.
/// </summary>
public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject consoleSpawner;
    private static bool initialized;

    private void Awake()
    {
        if (initialized)
            return;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Instantiate(consoleSpawner);
        initialized = true;
        Destroy(this.gameObject);
    }
}
