using Code.PlayerModule.Configs;
using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.TestModule.Systems
{
    public class TestSystem : ISystem
    {
        [Inject] private PlayerConfig _playerConfig;
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError(_playerConfig.speed);
            Debug.LogError("from TestSystems1");
        }
        
        public void Dispose()
        {
        }
    }
}