using System;
using UnityEngine;
using UnityEngine.UI;

namespace Madbox.CheatConsole.Internal
{
    public class ButtonCheatEntry : CheatEntry
    {
        [SerializeField] private Text textComponent;
        private Action callback;

        public override void SetCheat(ICheat cheat)
        {
            textComponent.text = cheat.Name;
            callback = ((ButtonCheat)cheat).Callback;
        }

        public void OnClick()
        {
            callback.Invoke();
        }
    }
}