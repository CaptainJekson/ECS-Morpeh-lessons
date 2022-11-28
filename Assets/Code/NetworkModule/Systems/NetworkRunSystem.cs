using System;
using Morpeh;
using Riptide;
using UnityEngine;
using Zenject;

namespace Code.NetworkModule.Systems
{
    public class NetworkRunSystem : ISystem
    {
        public World World { get; set; }

        [Inject] private Client _client;

        public void OnAwake()
        {
            _client.Connect("127.0.0.1:7777");
            _client.Connected += OnConnected;
        }

        public void OnUpdate(float deltaTime)
        {
            _client.Update();
        }
        
        public void Dispose()
        {
            _client.Connected -= OnConnected;
        }

        private void OnConnected(object sender, EventArgs e)
        {
            Debug.Log("Connected success");
        }
    }
}