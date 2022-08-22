using Code.UIModule.Configs;
using Code.UIModule.Utility;
using Morpeh;
using UnityEngine;

namespace Code.UIModule.Systems
{
    public class UiRootCreateSystem : IInitializer
    {
        private UiRootConfig _uiRootConfig;
        
        public World World { get; set; }

        public UiRootCreateSystem(UiRootConfig uiRootConfig)
        {
            _uiRootConfig = uiRootConfig;
        }

        public void OnAwake()
        {
            UiObjectStorage.uiRoot = Object.Instantiate(_uiRootConfig.uiRoot, _uiRootConfig.uiRoot.transform.position,
                Quaternion.identity);
        }
        
        public void Dispose()
        {
            _uiRootConfig = null;
        }
    }
}