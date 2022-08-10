using Code.CollisionModule.Installer;
using Code.EnemyModule.Installer;
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
            CollisionInstaller.Install(Container);
            PlayerInstaller.Install(Container);
            EnemyInstaller.Install(Container);

            Container.BindInstance(world);
        }
    }
}