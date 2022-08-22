using System.Collections.Generic;
using UnityEngine;

namespace Code.UIModule.Mono
{
    public class UiRoot : MonoBehaviour
    {
        [SerializeField] private List<Window> _windows;

        public T GetWindow<T>() where T : Window
        {
            foreach (var window in _windows)
            {
                if (window.GetType() == typeof(T))
                {
                    return window as T;
                }
            }

            return null;
        }
    }
}