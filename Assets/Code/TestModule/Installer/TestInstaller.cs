using Code.BaseUtils;
using Code.TestModule.Systems;
using Morpeh;
using Zenject;

namespace Code.TestModule.Installer
{
    public class TestInstaller : Installer<World, int, TestInstaller>
    {
        private World _world;
        private int _index;

        public TestInstaller(World world, int index)
        {
            _world = world;
            _index = index;
        }
        
        public override void InstallBindings()
        {
            var systemsGroup = _world.CreateSystemsGroup();

            systemsGroup.AddSystem(Container.BindSystem<TestSystem>());
            systemsGroup.AddSystem(Container.BindSystem<TestSystem2>());
            
            _world.AddSystemsGroup(_index, systemsGroup);
        }
    }
}