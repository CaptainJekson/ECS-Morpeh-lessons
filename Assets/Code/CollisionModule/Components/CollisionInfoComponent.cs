using Morpeh;
using UnityEngine;

namespace Code.CollisionModule.Components
{
    public struct CollisionInfoComponent : IComponent
    {
        public Entity currentEntity;
        public Collision otherCollison;
    }
}