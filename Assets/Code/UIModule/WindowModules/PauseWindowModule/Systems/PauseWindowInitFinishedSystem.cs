using Code.UIModule.WindowModules.PauseWindowModule.Components;
using Morpeh;

namespace Code.UIModule.WindowModules.PauseWindowModule.Systems
{
    public class PauseWindowInitFinishedSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PauseWindowDataComponent>().With<PauseWindowInitComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<PauseWindowInitComponent>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}