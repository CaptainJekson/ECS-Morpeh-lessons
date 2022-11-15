using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.BaseUtils
{
    public static class AddSystemExtension
    {
        public static IInitializer BindInitializer<T>(this DiContainer container) where T : class, IInitializer, new()
        {
            var instance = new T();
            container.BindInstance(instance).AsSingle();
            return instance;
        }
        
        public static ISystem BindSystem<T>(this DiContainer container) where T : class, ISystem, new()
        {
            var instance = new T();
            container.BindInstance(instance).AsSingle();
            return instance;
        }
        
        public static ISystem BindSystem<T, T2>(this DiContainer container, T2 so) 
            where T : class, ISystem, new()
            where T2: ScriptableObject
        {
            var instance = new T();
            container.BindInstance(instance).AsSingle();
            return instance;
        }
    }
}