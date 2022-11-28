using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.BaseUtils
{
    public static class AddSystemExtension
    {
        public static IInitializer BindInitializer<T>(this DiContainer container) where T : class, IInitializer, new()
        {
            var instance = container.Instantiate<T>();
            return instance;
        }
        
        public static ISystem BindSystem<T>(this DiContainer container) where T : class, ISystem, new()
        {
            var instance = container.Instantiate<T>();
            return instance;
        }
    }
}