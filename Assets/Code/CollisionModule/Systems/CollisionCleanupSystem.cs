using Code.CollisionModule.Components;
using Code.CollisionModule.Utility;
using Morpeh;

namespace Code.CollisionModule.Systems
{
    public class CollisionCleanupSystem : ILateSystem
    {
        private Filter _filter;
        private CollisionPool _collisionPool;
        
        public World World { get; set; }

        public CollisionCleanupSystem(CollisionPool collisionPool)
        {
            _collisionPool = collisionPool;
        }
       
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