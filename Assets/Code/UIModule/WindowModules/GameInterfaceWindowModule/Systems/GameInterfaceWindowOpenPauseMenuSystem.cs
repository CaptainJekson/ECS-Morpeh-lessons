using Code.UIModule.WindowModules.GameInterfaceWindowModule.Components;
using Code.UIModule.WindowModules.PauseWindowModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems
{
    public class GameInterfaceWindowOpenPauseMenuSystem : ISystem
    {
        private Filter _filter;
        private Filter _pauseWindowFilter;
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<GameInterfaceWindowDataComponent>().With<PauseButtonPressedComponent>();
            _pauseWindowFilter = World.Filter.With<PauseWindowDataComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<PauseButtonPressedComponent>();
                Time.timeScale = 0.0f;

                foreach (var entityPauseWindow in _pauseWindowFilter)
                {
                    ref var pauseWindow = ref entityPauseWindow.GetComponent<PauseWindowDataComponent>();
                    pauseWindow.gameObject.SetActive(true);
                }

            }
        }
        
        public void Dispose()
        {
            _filter = null;
            _pauseWindowFilter = null;
        }
    }
}