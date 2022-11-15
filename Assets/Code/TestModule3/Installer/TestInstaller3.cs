using Code.BaseUtils;
using Code.TestModule3.Systems;
using Morpeh;
using Zenject;

namespace Code.TestModule3.Installer
{
    public class TestInstaller3 : Installer<World, int, TestInstaller3>                   
    {                                                                                     
        private World _world;                                                             
        private int _index;                                                               
                                                                                      
        public TestInstaller3(World world, int index)                                     
        {                                                                                 
            _world = world;                                                               
            _index = index;                                                               
        }                                                                                 
                                                                                      
        public override void InstallBindings()                                            
        {                                                                                 
            var systemsGroup = _world.CreateSystemsGroup();                               
                                                                                      
            systemsGroup.AddSystem(Container.BindSystem<TestSystem5>());                
            systemsGroup.AddSystem(Container.BindSystem<TestSystem6>());                
                                                                                      
            _world.AddSystemsGroup(_index, systemsGroup);                                 
        }                                                                                 
    }                                                                                     
}