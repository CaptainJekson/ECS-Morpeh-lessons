using Code.PlayerModule.Providers;
using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.PlayerModule.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct PlayerSpawnerComponent : IComponent
    {
        public PlayerProvider player;
    }
}