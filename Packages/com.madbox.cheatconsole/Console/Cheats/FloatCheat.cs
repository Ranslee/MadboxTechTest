using Madbox.CheatConsole.Internal;
using System;

namespace Madbox.CheatConsole
{
    public class FloatCheat : ICheat
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public float CurrentValue { get; set; }
        public CheatEntry Prefab => DefaultCheatEntries.FloatCheatPrefab;
        
        public Action<float> Callback;
    }
}
