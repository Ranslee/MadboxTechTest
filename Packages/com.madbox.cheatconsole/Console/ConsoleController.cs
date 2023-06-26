using System.Collections.Generic;
using UnityEngine;
using Madbox.CheatConsole;

namespace Madbox.CheatConsole.Internal
{
    public class ConsoleController : MonoBehaviour
    {
        [SerializeField] private GameObject categoryContainer;
        [SerializeField] private GameObject cheatEntryContainer;
        [SerializeField] private CheatCategory categoryPrefab;

        [SerializeField] private GameObject buttonCheatPrefab;
        [SerializeField] private GameObject floatCheatPrefab;

        private Dictionary<string, List<ICheat>> cheatCollection;
        private List<CheatCategory> cheatCategories = new List<CheatCategory>();
        private List<CheatEntry> cheatEntries = new List<CheatEntry>();
        private int currentCategory = -1;


        public void Close()
        {
            Destroy(this.gameObject);
        }

        public void SetCheatCollection(Dictionary<string, List<ICheat>> sourceCheatCollection)
        {
            SetDefaultCheatEntryPrefabs();
            cheatCollection = sourceCheatCollection;
            if (sourceCheatCollection.Count > 0)
            {
                BuildCategories();
                DisplayCategory(0);
            }
        }

        private void BuildCategories()
        {
            foreach (var pair in cheatCollection)
            {
                var cheatCategory = Instantiate(categoryPrefab, categoryContainer.transform);

                cheatCategory.CategoryName = pair.Key;
                cheatCategory.SetCallback(DisplayCategory, cheatCategories.Count);

                cheatCategories.Add(cheatCategory);
            }
        }

        private void DisplayCategory(int index)
        {
            if (currentCategory == index)
                return;

            ClearCheatEntries();
            var cheatList = cheatCollection[cheatCategories[index].CategoryName];

            for (int i = 0; i < cheatList.Count; i++)
            {
                var cheat = cheatList[i];
                var cheatEntry = Instantiate(cheat.Prefab, cheatEntryContainer.transform);
                cheatEntry.SetCheat(cheat);
                cheatEntries.Add(cheatEntry);
            }

            currentCategory = index;
        }

        private void ClearCheatEntries()
        {
            for (int i = 0; i < cheatEntries.Count; i++)
            {
                Destroy(cheatEntries[i].gameObject);
            }

            cheatEntries.Clear();
        }

        private void SetDefaultCheatEntryPrefabs()
        {
            DefaultCheatEntries.ButtonCheatPrefab = buttonCheatPrefab.GetComponent<ButtonCheatEntry>();
            DefaultCheatEntries.FloatCheatPrefab = floatCheatPrefab.GetComponent<FloatCheatEntry>();
        }
    }
}