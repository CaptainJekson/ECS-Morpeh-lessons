using Code.CollisionModule.Components;
using Code.CollisionModule.Utility;
using Morpeh;
using Zenject;

namespace Code.CollisionModule.Systems
{
    public class CollisionCleanupSystem : ILateSystem
    {
        [Inject] private CollisionPool _collisionPool;
        
        private Filter _filter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<CollisionInfoComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                _collisionPool.ReturnInPoolEntity(entity);
            }
        } 
        
        public void Dispose()
        {
            _filter = null;
            _collisionPool = null;
        }
    }
}