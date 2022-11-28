using Code.BaseUtils;
using Code.NetworkModule.Components;
using Morpeh;
using Riptide;
using UnityEngine;
using Zenject;

namespace Code.NetworkModule.Systems
{
    public class TestSendMessageSystem : ISystem
    {
        [Inject] private Client _client;

        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<TestMessage>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var testMessage = ref entity.GetComponent<TestMessage>();
                
                var message = Message.Create(MessageSendMode.Unreliable, 2);
                message.AddString(testMessage.StrTest);
                message.AddInt(testMessage.IntTest);
                message.AddFloat(testMessage.FloatTest);
                _client.Send(message);
                Debug.LogError($"Отправка сообщения {testMessage.StrTest} | {testMessage.IntTest} | {testMessage.FloatTest}");
                entity.RemoveComponent<TestMessage>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}