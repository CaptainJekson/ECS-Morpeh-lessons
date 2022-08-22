using System;
using Code.UIModule.WindowModules.PauseWindowModule.Components;
using Morpeh;
using UnityEngine;

namespace Code.UIModule.WindowModules.PauseWindowModule.Systems
{
    public class PauseWindowCloseSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<PauseWindowDataComponent>().With<CloseButtonPressedComponent>();
        } 
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<CloseButtonPressedComponent>();
                Time.timeScale = 1.0f;

                ref var windowData = ref entity.GetComponent<PauseWindowDataComponent>();
                windowData.gameObject.SetActive(false);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}