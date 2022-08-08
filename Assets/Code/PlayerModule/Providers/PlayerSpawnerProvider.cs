using Code.PlayerModule.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.PlayerModule.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PlayerSpawnerProvider : MonoProvider<PlayerSpawnerComponent>
    {
    }
}    