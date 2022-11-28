using Code.PlayerModule.Components;
using Code.PlayerModule.Configs;
using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.PlayerModule.Systems
{
    public sealed class PlayerMoveSystem : ISystem
    {
        [Inject] private PlayerConfig _playerConfig;
        
        private Filter _filter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerComponent>().With<PlayerMoveComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)    
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
                ref var playerMoveComponent = ref entity.GetComponent<PlayerMoveComponent>();
        
                var currentPosition = playerComponent.transform.position;
        
                currentPosition = Vector3.MoveTowards(currentPosition, currentPosition + playerMoveComponent.direction,
                    _playerConfig.speed * Time.deltaTime);
        
                playerComponent.transform.position = currentPosition;
        
                entity.RemoveComponent<PlayerMoveComponent>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}