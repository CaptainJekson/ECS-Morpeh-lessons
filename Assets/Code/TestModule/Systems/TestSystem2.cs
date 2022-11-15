using Morpeh;
using UnityEngine;

namespace Code.TestModule.Systems
{
    public class TestSystem2 : ISystem
    {
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError("from TestSystems2");
        }
        
        public void Dispose()
        {
        }
    }
}