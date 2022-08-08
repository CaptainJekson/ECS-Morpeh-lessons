using Code.PlayerModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.PlayerModule.Systems
{
    public sealed class PlayerInputSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }  
        
        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
        
                if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
                {
                    var verticalAxis = Input.GetAxis("Vertical");
                    var horizontalAxis = Input.GetAxis("Horizontal");
                    var direction = new Vector3(horizontalAxis, 0.0f, verticalAxis);
                    
                    entity.SetComponent(new PlayerMoveComponent
                    {
                        direction = direction,
                        speed = playerComponent.speed,
                    });
                }
        
                if (Input.GetButtonUp("Jump")) 
                {
                    entity.SetComponent(new PlayerJumpComponent());
                }
            }
        }
        public void Dispose()
        {
            _filter = null;
        }
    }
}