using Code.EnemyModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.EnemyModule.Systems
{
    public class EnemyCreateSystem : IInitializer
    {
        private Filter _filter;
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<EnemySpawnerComponent>();

            foreach (var entity in _filter)
            {
                ref var playerSpawnerComponent = ref entity.GetComponent<EnemySpawnerComponent>();

                for (var i = 0; i < playerSpawnerComponent.countEnemy; i++)
                {
                    var positionX = Random.Range(playerSpawnerComponent.spawnPositionMin.x,
                        playerSpawnerComponent.spawnPositionMax.x);
                    var positionY = playerSpawnerComponent.enemy.transform.position.y;
                    var positionZ = Random.Range(playerSpawnerComponent.spawnPositionMin.y,
                        playerSpawnerComponent.spawnPositionMax.y);

                    Object.Instantiate(playerSpawnerComponent.enemy,
                        new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}