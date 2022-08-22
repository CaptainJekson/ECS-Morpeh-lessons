using Code.BaseInstaller;
using Code.PlayerModule.Systems;
using Morpeh;

namespace Code.PlayerModule.Installer
{
    public sealed class PlayerExecutor : Executor
    {
        public PlayerExecutor(World world,
            PlayerCreateSystem playerCreateSystem,
            PlayerInputSystem playerInputSystem,
            PlayerMoveSystem playerMoveSystem,
            PlayerJumpSystem playerJumpSystem,
            PlayerDamageSystem playerDamageSystem,
            PlayerDamageCleanupSystem playerDamageCleanupSystem) : base(world)
        {
            _initializersSystems.AddInitializer(playerCreateSystem);
            _updateSystems.AddSystem(playerInputSystem);
            _updateSystems.AddSystem(playerMoveSystem);
            _updateSystems.AddSystem(playerJumpSystem);
            _updateSystems.AddSystem(playerDamageSystem);
            _lateUpdateSystems.AddSystem(playerDamageCleanupSystem);
        }
    }
}