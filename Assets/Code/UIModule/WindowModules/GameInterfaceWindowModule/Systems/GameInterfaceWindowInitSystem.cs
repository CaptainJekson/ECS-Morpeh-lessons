using Code.PlayerModule.Components;
using Code.UIModule.Utility;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Components;
using Morpeh;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems
{
    public class GameInterfaceWindowInitSystem : ISystem
    {
        private Filter _filter;
        private Filter _playerFilter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<GameInterfaceWindowDataComponent>().With<GameInterfaceWindowInitComponent>();
            _playerFilter = World.Filter.With<PlayerComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var windowData = ref entity.GetComponent<GameInterfaceWindowDataComponent>();
                
                windowData.pauseButton.OnClickAdd<PauseButtonPressedComponent>(entity);

                SetDataHealthBar(windowData);
            }
        }

        private void SetDataHealthBar(GameInterfaceWindowDataComponent windowData)
        {
            foreach (var entity in _playerFilter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();

                windowData.healthText.text = string.Format($"{playerComponent.life} / {playerComponent.life}");
                windowData.healthBar.fillAmount = 1.0f;
            }
        }
        
        public void Dispose()
        {
            _filter = null;
            _playerFilter = null;
        }
    }
}