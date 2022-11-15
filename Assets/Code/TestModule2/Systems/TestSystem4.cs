using Morpeh;
using UnityEngine;

namespace Code.TestModule2.Systems
{
    public class TestSystem4 : ISystem
    {
        public World World { get; set; }

        public void OnAwake()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.LogError("from TestSystems4");
        }
        
        public void Dispose()
        {
        }
    }
}