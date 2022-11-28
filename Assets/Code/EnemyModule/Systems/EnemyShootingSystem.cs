using Code.CollisionModule.Providers;
using Code.CollisionModule.Utility;
using Code.EnemyModule.Components;
using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.EnemyModule.Systems
{
    public class EnemyShootingSystem : ISystem
    {
        [Inject] private CollisionPool _collisionPool;
        
        private Filter _filter;

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