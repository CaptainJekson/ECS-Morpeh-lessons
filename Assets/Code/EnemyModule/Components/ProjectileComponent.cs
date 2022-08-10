using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.EnemyModule.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct ProjectileComponent : IComponent
    {
        public Transform transform;
        public Rigidbody rigidbody;
        public float speed;
    }
}