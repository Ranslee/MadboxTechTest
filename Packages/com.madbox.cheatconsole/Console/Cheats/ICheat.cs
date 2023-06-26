using Madbox.CheatConsole.Internal;

namespace Madbox.CheatConsole
{
    public interface ICheat
    {
        public string Category { get; }
        public string Name { get; }
        public CheatEntry Prefab { get; }
    }
}