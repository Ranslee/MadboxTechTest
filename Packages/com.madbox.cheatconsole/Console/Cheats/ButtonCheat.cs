using Madbox.CheatConsole.Internal;
using System;

namespace Madbox.CheatConsole
{
    public class ButtonCheat : ICheat
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public CheatEntry Prefab => DefaultCheatEntries.ButtonCheatPrefab;
        public Action Callback;
    }
}
