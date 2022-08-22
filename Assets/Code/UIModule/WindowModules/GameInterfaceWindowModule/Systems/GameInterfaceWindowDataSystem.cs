using Code.PlayerModule.Components;
using Code.UIModule.Utility;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Components;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Mono;
using Morpeh;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems
{
    public class GameInterfaceWindowDataSystem : ISystem
    {
        private Filter _filter;
        private Filter _playerFilter;
        private GameInterfaceWindow _gameInterfaceWindow;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _gameInterfaceWindow = UiObjectStorage.uiRoot.GetWindow<GameInterfaceWindow>();
            
            World.CreateEntity().SetComponent(new GameInterfaceWindowCreateComponent());
            _filter = World.Filter.With<GameInterfaceWindowCreateComponent>();
            _playerFilter = World.Filter.With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.SetComponent(new GameInterfaceWindowDataComponent
                {
                    gameObject = _gameInterfaceWindow.gameObject,
                    healthBar =  _gameInterfaceWindow.healthBar,
                    healthText = _gameInterfaceWindow.healthText,
                    pauseButton = _gameInterfaceWindow.pauseButton,
                    maxLife = GetPlayerMaxLife(),
                });
                
                entity.SetComponent(new GameInterfaceWindowInitComponent());
                
                entity.RemoveComponent<GameInterfaceWindowCreateComponent>();
            }
        }

        private int GetPlayerMaxLife()
        {
            foreach (var entity in _playerFilter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
                return playerComponent.life;
            }

            return 0;
        }
        
        public void Dispose()
        {
            _filter = null;
            _playerFilter = null;
        }
    }
}