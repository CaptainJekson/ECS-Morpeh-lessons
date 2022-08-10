using Code.EnemyModule.Providers;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.EnemyModule.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct EnemySpawnerComponent : IComponent
    {
        public EnemyProvider enemy;
        public Vector2 spawnPositionMax;
        public Vector2 spawnPositionMin;
        public int countEnemy;
    }
}