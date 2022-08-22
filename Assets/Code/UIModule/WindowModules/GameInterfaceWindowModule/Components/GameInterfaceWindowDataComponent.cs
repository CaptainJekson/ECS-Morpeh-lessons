using Morpeh;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Components
{
    public struct GameInterfaceWindowDataComponent : IComponent
    {
        public GameObject gameObject;
        public Image healthBar;
        public TextMeshProUGUI healthText;
        public Button pauseButton;
        public int maxLife;
    }
}