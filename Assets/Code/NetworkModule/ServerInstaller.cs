using Code.BaseUtils;
using Code.NetworkModule.Systems;
using Morpeh;
using Riptide;
using Zenject;

namespace Code.NetworkModule
{
    public class ServerInstaller : Installer<World, int, ServerInstaller>
    {
        private World _world;
        private int _index;

        public ServerInstaller(World world, int index)
        {
            _world = world;
            _index = index;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<Client>().AsSingle();
            
            var systemsGroup = _world.CreateSystemsGroup();
            
            systemsGroup.AddSystem(Container.BindSystem<NetworkRunSystem>());

            systemsGroup.AddSystem(Container.BindSystem<TestInputSendMessage>());
            systemsGroup.AddSystem(Container.BindSystem<TestSendMessageSystem>());
            
            _world.AddSystemsGroup(_index, systemsGroup);
        }
    }
}