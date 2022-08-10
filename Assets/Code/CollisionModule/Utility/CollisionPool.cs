using System.Collections.Generic;
using Code.CollisionModule.Components;
using Morpeh;

namespace Code.CollisionModule.Utility
{
    public class CollisionPool
    {
        private World _world;
        private Stack<Entity> _pool;

        public CollisionPool(World world)
        {
            _world = world;
            _pool = new Stack<Entity>();
        }

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
            var entity = _world.CreateEntity();
            entity.AddComponent<CollisionComponent>();
            return entity;
        }
    }
}