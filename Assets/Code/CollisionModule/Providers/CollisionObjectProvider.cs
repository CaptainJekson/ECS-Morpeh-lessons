using Code.CollisionModule.Components;
using Code.CollisionModule.Utility;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.CollisionModule.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class CollisionObjectProvider : MonoProvider<CollisionObjectComponent>
    {
        private CollisionPool _collisionPool;

        public void InitPool(CollisionPool collisionPool)
        {
            _collisionPool = collisionPool;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(_collisionPool == null)
                return;
            
            var entity = _collisionPool.GetCollisionEntity();
            entity.SetComponent(new CollisionInfoComponent
            {
                currentEntity = Entity,
                otherCollison = other,
            });
        }
    }
}