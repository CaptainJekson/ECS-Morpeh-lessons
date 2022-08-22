using Morpeh;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UIModule.WindowModules.PauseWindowModule.Components
{
    public struct PauseWindowDataComponent : IComponent
    {
        public GameObject gameObject;
        public Button[] closeButton;
    }
}