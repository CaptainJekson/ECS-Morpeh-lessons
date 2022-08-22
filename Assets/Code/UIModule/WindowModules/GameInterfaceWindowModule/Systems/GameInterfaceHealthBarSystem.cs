using Code.PlayerModule.Components;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Components;
using Morpeh;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems
{
    public class GameInterfaceHealthBarSystem : ISystem
    {
        private Filter _playerDamageFilter;
        private Filter _windowFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _playerDamageFilter = World.Filter.With<PlayerComponent>().With<DamageComponent>();
            _windowFilter = World.Filter.With<GameInterfaceWindowDataComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var playerEntity in _playerDamageFilter)
            {
                ref var playerComponent = ref playerEntity.GetComponent<PlayerComponent>();
                var currentLife = playerComponent.life;

                foreach (var windowEntity in _windowFilter)
                {
                    ref var windowData = ref windowEntity.GetComponent<GameInterfaceWindowDataComponent>();

                    windowData.healthText.text = string.Format($"{currentLife} / {windowData.maxLife}");
                    windowData.healthBar.fillAmount = (float) currentLife / windowData.maxLife;
                }
            }
        }
        
        public void Dispose()
        {
            _playerDamageFilter = null;
            _windowFilter = null;
        }
    }
}