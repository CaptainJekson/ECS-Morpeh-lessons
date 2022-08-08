using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.PlayerModule.Components
{
    public struct PlayerMoveComponent : IComponent
    {
        public Vector3 direction;
        public float speed;
    }
}