using Code.BaseUtils;
using Code.EnemyModule.Systems;
using Morpeh;
using Zenject;

namespace Code.EnemyModule.Installer
{
    public class EnemyInstaller : Installer<World, int, EnemyInstaller>
    {
        private World _world;
        private int _index;

        public EnemyInstaller(World world, int index)
        {
            _world = world;
            _index = index;
        }
        
        public override void InstallBindings()
        {
            var systemsGroup = _world.CreateSystemsGroup();

            systemsGroup.AddInitializer(Container.BindInitializer<EnemyCreateSystem>());
            systemsGroup.AddSystem(Container.BindSystem<EnemyShootingSystem>());
            systemsGroup.AddSystem(Container.BindSystem<EnemyProjectileTargetSystem>());
            systemsGroup.AddSystem(Container.BindSystem<EnemyProjectileMoveSystem>());
            
            _world.AddSystemsGroup(_index, systemsGroup);
        }
    }
}