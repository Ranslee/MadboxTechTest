using System;
using UnityEngine;
using UnityEngine.UI;
using Madbox.CheatConsole;

namespace Madbox.CheatConsole.Internal
{
    public class FloatCheatEntry : CheatEntry
    {
        [SerializeField] private Text nameTextComponent;
        [SerializeField] private Text valueTextComponent;
        private Action<float> callback;
        private FloatCheat cachedCheat;

        public override void SetCheat(ICheat cheat)
        {
            nameTextComponent.text = cheat.Name;
            this.cachedCheat = ((FloatCheat)cheat);
            callback = cachedCheat.Callback;
            valueTextComponent.text = cachedCheat.CurrentValue.ToString();
        }

        public void OnValueSubmit(string val)
        {
            if (float.TryParse(val, out float result))
            {
                callback.Invoke(result);
                cachedCheat.CurrentValue = result;
            }
        }
    }
}