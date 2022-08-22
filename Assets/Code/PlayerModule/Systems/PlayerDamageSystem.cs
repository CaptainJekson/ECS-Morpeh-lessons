using Code.CollisionModule.Components;
using Code.PlayerModule.Components;
using Code.PlayerModule.Providers;
using Morpeh;
using UnityEngine;

namespace Code.PlayerModule.Systems
{
    public class PlayerDamageSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<CollisionComponent>().With<CollisionInfoComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var collisionInfoComponent = ref entity.GetComponent<CollisionInfoComponent>();
                var other = collisionInfoComponent.otherCollison;
                var current = collisionInfoComponent.currentEntity;
                
                if(other.gameObject.GetComponent<PlayerProvider>() == false)
                    return;

                var playerEntity = other.gameObject.GetComponent<PlayerProvider>().Entity;

                ref var playerComponent = ref playerEntity.GetComponent<PlayerComponent>();

                if (playerComponent.life > 0)
                {
                    playerComponent.life--;
                    Debug.Log(playerComponent.life);
                    playerEntity.SetComponent(new DamageComponent());
                }
                else
                {
                    Object.Destroy(playerComponent.transform.gameObject);
                    World.RemoveEntity(playerEntity);
                    Debug.Log("Игрок скончался!");
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}