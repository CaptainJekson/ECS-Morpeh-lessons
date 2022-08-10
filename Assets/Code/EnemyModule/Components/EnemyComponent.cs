using Code.EnemyModule.Providers;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.EnemyModule.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct EnemyComponent : IComponent
    {
        public Transform transform;
        public ProjectileProvider projectile;
        public float shootingRateMin;
        public float shootingRateMax;
        public float currentRate;
    }
}