using Code.NetworkModule;
using Code.PlayerModule.Installer;
using Morpeh;
using Zenject;

namespace Code.BaseInstaller
{
    public class StartupInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var world = World.Default;

            var index = 0;
            
            ServerInstaller.Install(Container, world, index);
            
            //CollisionInstaller.Install(Container, world, index++);
            //PlayerInstaller.Install(Container, world, index++);
            //EnemyInstaller.Install(Container, world, index++);
            //UiInstaller.Install(Container, world, index++);
            
            //TestInstaller.Install(Container, world, index++);
            //TestInstaller2.Install(Container,world, index++);
            //TestInstaller3.Install(Container,world, index);

            Container.BindInstance(world);
        }
    }
}