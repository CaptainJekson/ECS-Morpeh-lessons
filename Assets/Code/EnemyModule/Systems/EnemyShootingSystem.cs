using Code.CollisionModule.Providers;
using Code.CollisionModule.Utility;
using Code.EnemyModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.EnemyModule.Systems
{
    public class EnemyShootingSystem : ISystem
    {
        private Filter _filter;
        private CollisionPool _collisionPool;

        public EnemyShootingSystem(CollisionPool collisionPool)
        {
            _collisionPool = collisionPool;
        }
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<EnemyComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var enemyComponent = ref entity.GetComponent<EnemyComponent>();

                if (enemyComponent.currentRate <= 0)
                {
                    enemyComponent.currentRate =
                        Random.Range(enemyComponent.shootingRateMin, enemyComponent.shootingRateMax);

                    var spawnedProjectile = Object.Instantiate(enemyComponent.projectile, enemyComponent.transform.position,
                        Quaternion.identity);
                    
                    spawnedProjectile.GetComponent<CollisionObjectProvider>().InitPool(_collisionPool);
                }
                else
                {
                    enemyComponent.currentRate -= deltaTime;
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}