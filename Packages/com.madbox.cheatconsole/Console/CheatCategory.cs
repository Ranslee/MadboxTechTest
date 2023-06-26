using System;
using UnityEngine;
using UnityEngine.UI;

namespace Madbox.CheatConsole.Internal
{
    public class CheatCategory : MonoBehaviour
    {
        [SerializeField] private Button buttonComponent;
        [SerializeField] private Text textComponent;

        private Action<int> callback;
        private int index;

        private string categoryName;
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                textComponent.text = value;
                categoryName = value;
            }
        }

        public void SetCallback(Action<int> callback, int index)
        {
            this.callback = callback;
            this.index = index;
        }

        public void ChangeCategory()
        {
            callback.Invoke(index);
        }
    }
}