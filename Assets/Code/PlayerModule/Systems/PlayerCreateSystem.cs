using Code.PlayerModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.PlayerModule.Systems
{
    public sealed class PlayerCreateSystem : IInitializer
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerSpawnerComponent>();
        
            foreach (var entity in _filter)
            {
                ref var playerSpawnerComponent = ref entity.GetComponent<PlayerSpawnerComponent>();
                var player = playerSpawnerComponent.player;
        
                Object.Instantiate(player, player.transform.position, Quaternion.identity);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}