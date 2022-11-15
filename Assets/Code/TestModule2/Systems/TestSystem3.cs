using Morpeh;
using UnityEngine;

namespace Code.TestModule2.Systems
{
    public class TestSystem3 : ISystem
    {
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError("from TestSystems3");
        }
        
        public void Dispose()
        {
        }
    }
}