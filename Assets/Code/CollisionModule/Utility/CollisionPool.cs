using System.Collections.Generic;
using Code.CollisionModule.Components;
using Morpeh;
using Zenject;

namespace Code.CollisionModule.Utility
{
    public class CollisionPool
    {
        //private World _world;  
        private Stack<Entity> _pool;

        public Entity GetCollisionEntity()
        {
            var isPoolEntry = _pool.TryPop(out var entity);

            if (isPoolEntry == false)
            {
                entity = GenerateNewEntity();
            }

            return entity;
        }

        public void ReturnInPoolEntity(Entity entity)
        {
            entity.RemoveComponent<CollisionInfoComponent>();
            _pool.Push(entity);
        }

        private Entity GenerateNewEntity()
        {
            //var entity = _world.CreateEntity();
            //entity.AddComponent<CollisionComponent>();
            return default;
        }
    }
}