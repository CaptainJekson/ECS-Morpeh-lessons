using Code.UIModule.WindowModules.GameInterfaceWindowModule.Components;
using Morpeh;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems
{
    public class GameInterfaceWindowInitFinishedSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<GameInterfaceWindowDataComponent>().With<GameInterfaceWindowInitComponent>(); 
        }   
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<GameInterfaceWindowInitComponent>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}