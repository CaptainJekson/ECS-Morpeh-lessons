using Code.EnemyModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.EnemyModule.Systems
{
    public class EnemyProjectileMoveSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<ProjectileComponent>().With<ProjectileMoveComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var projectileComponent = ref entity.GetComponent<ProjectileComponent>();
                ref var projectileMoveComponent = ref entity.GetComponent<ProjectileMoveComponent>();
                var position = projectileComponent.transform.position;
                var projectilePositionXZ = new Vector3(position.x, 0.0f, position.z);

                var direction = (projectileMoveComponent.targetPosition - projectilePositionXZ).normalized;
                
                projectileComponent.rigidbody.AddForce(direction * projectileComponent.speed, ForceMode.Force);

                if (Vector3.Distance(projectilePositionXZ, projectileMoveComponent.targetPosition) < 0.5f)
                {
                    Object.Destroy(projectileComponent.transform.gameObject);
                    World.RemoveEntity(entity);
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}