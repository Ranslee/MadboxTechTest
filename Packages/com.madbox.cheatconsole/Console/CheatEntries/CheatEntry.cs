using System;
using UnityEngine;
using UnityEngine.UI;

namespace Madbox.CheatConsole.Internal
{
    public abstract class CheatEntry : MonoBehaviour
    {
        public abstract void SetCheat(ICheat cheat);
    }
}