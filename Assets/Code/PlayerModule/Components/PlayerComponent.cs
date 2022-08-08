using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.PlayerModule.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct PlayerComponent : IComponent
    {
        public Transform transform;
        public Rigidbody rigidbody;
        public float speed;
        public float jumpForce;
    }
}