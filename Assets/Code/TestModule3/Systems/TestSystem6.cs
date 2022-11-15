using Morpeh;
using UnityEngine;

namespace Code.TestModule3.Systems
{
    public class TestSystem6 : ISystem
    {
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError("from TestSystems6");
        }
        
        public void Dispose()
        {
        }
    }
}