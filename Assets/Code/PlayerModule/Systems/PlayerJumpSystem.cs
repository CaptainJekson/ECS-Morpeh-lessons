using Code.PlayerModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.PlayerModule.Systems
{
    public sealed class PlayerJumpSystem : ISystem
    {   
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerComponent>().With<PlayerJumpComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
                
                playerComponent.rigidbody.AddForce(new Vector3(0.0f,playerComponent.jumpForce,0.0f),
                    ForceMode.Impulse);
        
                entity.RemoveComponent<PlayerJumpComponent>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}