using Morpeh;
using UnityEngine;

namespace Code.TestModule3.Systems
{
    public class TestSystem5 : ISystem
    {
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError("from TestSystems5");
        }
        
        public void Dispose()
        {
        }
    }
}