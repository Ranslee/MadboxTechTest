using UnityEngine;
using Madbox.CheatConsole;

public class ConsoleSpawner : MonoBehaviour
{
    private GameObject console;

    private void Awake()
    {
        MBCheatConsole.RegisterCheat(new ButtonCheat
        {
            Category = "Core",
            Name = "Close Game",
            Callback = () => { Application.Quit(); }
        });
    }

    private void Update()
    {
        if ((Input.touchCount > 4 || Input.GetKeyDown(KeyCode.F1)) && console == null)
        {
            SpawnConsole();
        }
    }

    private void SpawnConsole()
    {
        MBCheatConsole.Load(ConsoleLoaded);
    }

    private void ConsoleLoaded(GameObject console)
    {
        this.console = console;
    }
}
