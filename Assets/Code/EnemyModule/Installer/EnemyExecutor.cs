using Code.BaseInstaller;
using Code.EnemyModule.Systems;
using Morpeh;

namespace Code.EnemyModule.Installer
{
    public sealed class EnemyExecutor : Executor
    {
        public EnemyExecutor(World world,
            EnemyCreateSystem enemyCreateSystem,
            EnemyShootingSystem enemyShootingSystem,
            EnemyProjectileTargetSystem enemyProjectileTargetSystem,
            EnemyProjectileMoveSystem enemyProjectileMoveSystem) : base(world)
        {
            _initializersSystems.AddInitializer(enemyCreateSystem);
            _updateSystems.AddSystem(enemyShootingSystem);
            _updateSystems.AddSystem(enemyProjectileTargetSystem);
            _updateSystems.AddSystem(enemyProjectileMoveSystem);
        }
    }
}