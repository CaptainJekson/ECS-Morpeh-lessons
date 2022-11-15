using Code.TestModule.Installer;
using Code.TestModule2.Installer;
using Code.TestModule3.Installer;
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
            
            TestInstaller.Install(Container, world, index++);
            TestInstaller2.Install(Container,world, index++);
            TestInstaller3.Install(Container,world, index);

            Container.BindInstance(world);
        }
    }
}