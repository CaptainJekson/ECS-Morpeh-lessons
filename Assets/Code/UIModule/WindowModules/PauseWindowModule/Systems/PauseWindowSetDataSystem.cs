using Code.UIModule.Utility;
using Code.UIModule.WindowModules.PauseWindowModule.Components;
using Code.UIModule.WindowModules.PauseWindowModule.Mono;
using Morpeh;

namespace Code.UIModule.WindowModules.PauseWindowModule.Systems
{
    public class PauseWindowSetDataSystem : ISystem
    {
        private Filter _filter;
        private PauseWindow _pauseWindow;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _pauseWindow = UiObjectStorage.uiRoot.GetWindow<PauseWindow>();
             
            World.CreateEntity().SetComponent(new PauseWindowCreateComponent());

            _filter = World.Filter.With<PauseWindowCreateComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.SetComponent(new PauseWindowDataComponent
                {
                    gameObject = _pauseWindow.gameObject,
                    closeButton = _pauseWindow.closeButton,
                });
                
                entity.SetComponent(new PauseWindowInitComponent());
                entity.RemoveComponent<PauseWindowCreateComponent>();
            }
        }

        public void Dispose()
        {
            _filter = null;
            _pauseWindow = null;
        }
    }
}