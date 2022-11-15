using Code.BaseUtils;
using Code.TestModule2.Systems;
using Morpeh;
using Zenject;

namespace Code.TestModule2.Installer
{
    public class TestInstaller2 : Installer<World, int, TestInstaller2>
    {
        private World _world;
        private int _index;

        public TestInstaller2(World world, int index)
        {
            _world = world;
            _index = index;
        }
        
        public override void InstallBindings()
        {
            var systemsGroup = _world.CreateSystemsGroup();
            
            systemsGroup.AddSystem(Container.BindSystem<TestSystem3>());
            systemsGroup.AddSystem(Container.BindSystem<TestSystem4>());
            
            _world.AddSystemsGroup(_index, systemsGroup);
        }
    }
}