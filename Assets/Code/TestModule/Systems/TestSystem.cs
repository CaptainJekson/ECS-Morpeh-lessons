using Code.PlayerModule.Configs;
using Morpeh;
using UnityEngine;

namespace Code.TestModule.Systems
{
    public class TestSystem : ISystem
    {
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError("from TestSystems1");
        }
        
        public void Dispose()
        {
        }
    }
}