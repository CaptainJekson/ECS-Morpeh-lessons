using Code.NetworkModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.NetworkModule.Systems
{
    public class TestInputSendMessage : ISystem
    {
        public World World { get; set; }
        
        public void OnAwake()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                var entity = World.CreateEntity();
                entity.SetComponent(new TestMessage
                {
                    StrTest = "Привет с клиента",
                    IntTest = 777,
                    FloatTest = 145121.0f,
                });
            }
        }
        
        public void Dispose()
        {
            
        }
    }
}