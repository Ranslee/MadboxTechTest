using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Madbox.CheatConsole.Internal;

namespace Madbox.CheatConsole
{
    public static class MBCheatConsole
    {
        private const string CONSOLE_ADDRESS = "Packages/com.madbox.modules.console/Prefabs/Console.prefab";
        private static List<Action<GameObject>> callbacks = new List<Action<GameObject>>();
        private static GameObject console;
        private static bool loadingConsole;

        private static Dictionary<string, List<ICheat>> cheatCollection = new Dictionary<string, List<ICheat>>();

        public static void Load(Action<GameObject> callback)
        {
            if (console != null)
            {
                callback.Invoke(console);
                return;
            }

            callbacks.Add(callback);

            if (loadingConsole == false)
            {
                loadingConsole = true;
                Addressables.LoadAssetAsync<GameObject>(CONSOLE_ADDRESS).Completed += OnConsoleAssetLoaded;
            }
        }

        private static void OnConsoleAssetLoaded(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                console = Transform.Instantiate(handle.Result);
                console.GetComponent<ConsoleController>().SetCheatCollection(cheatCollection);

                for (int i = 0; i < callbacks.Count; i++)
                {
                    var callback = callbacks[i];
                    if (callback.Target != null)
                    {
                        callback.Invoke(console);
                    }

                    callbacks.Clear();
                }
            }
            else
            {
                UnityEngine.Debug.LogError("Console failed to load.");
            }

            loadingConsole = false;
            Addressables.Release(handle);
        }

        //[Conditional("CHEATS_ENABLED")] // We would use something like this to strip console code from non-dev builds
        public static void RegisterCheat(ICheat cheat)
        {
            Debug.Log($"Attempting to register cheat {cheat.Category}-{cheat.Name}.");
            if (cheatCollection.TryGetValue(cheat.Category, out List<ICheat> list))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == cheat.Name)
                    {
                        Debug.Log($"Cheat {cheat.Category}-{cheat.Name} not added, duplicate name found.");
                        return;
                    }
                }

                cheatCollection[cheat.Category].Add(cheat);
                Debug.Log($"Registered cheat {cheat.Category}-{cheat.Name}.");
            }
            else
            {
                cheatCollection.Add(cheat.Category, new List<ICheat>());
                cheatCollection[cheat.Category].Add(cheat);
                Debug.Log($"Registered cheat {cheat.Category}-{cheat.Name}.");
            }
        }
    }
}