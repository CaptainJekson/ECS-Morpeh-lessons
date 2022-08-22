using Code.PlayerModule.Components;
using Morpeh;

namespace Code.PlayerModule.Systems
{
    public class PlayerDamageCleanupSystem : ILateSystem
    {
        private Filter _filter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<DamageComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<DamageComponent>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}