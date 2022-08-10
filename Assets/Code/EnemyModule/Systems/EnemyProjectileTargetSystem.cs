using System;
using Code.EnemyModule.Components;
using Code.PlayerModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.EnemyModule.Systems
{
    public class EnemyProjectileTargetSystem : ISystem
    {
        private Filter _projectileFilter;
        private Filter _playerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _projectileFilter = World.Filter.With<ProjectileComponent>().Without<ProjectileMoveComponent>();
            _playerFilter = World.Filter.With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var projectileEntity in _projectileFilter)
            {
                foreach (var playerEntity in _playerFilter)
                {
                    ref var playerComponent = ref playerEntity.GetComponent<PlayerComponent>();

                    var playerPosition = playerComponent.transform.position;
                    
                    projectileEntity.SetComponent(new ProjectileMoveComponent
                    {
                        targetPosition = new Vector3(playerPosition.x, 0.0f, playerPosition.z),
                    });
                }
            }
        }
        
        public void Dispose()
        {
            _projectileFilter = null;
            _playerFilter = null;
        }
    }
}