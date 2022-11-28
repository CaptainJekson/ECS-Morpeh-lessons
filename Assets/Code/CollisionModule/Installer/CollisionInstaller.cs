using Code.BaseUtils;
using Code.CollisionModule.Systems;
using Code.CollisionModule.Utility;
using Morpeh;
using Zenject;

namespace Code.CollisionModule.Installer
{
    public class CollisionInstaller : Installer<World, int, CollisionInstaller>
    {
        private World _world;
        private int _index;

        public CollisionInstaller(World world, int index)
        {
            _world = world;
            _index = index;
        }
        
        public override void InstallBindings()
        {
            var systemsGroup = _world.CreateSystemsGroup();
            
            Container.Bind<CollisionPool>().AsSingle();
            
            systemsGroup.AddSystem(Container.BindSystem<CollisionCleanupSystem>());
            
            _world.AddSystemsGroup(_index, systemsGroup);
        }
    }
}
