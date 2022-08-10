using Code.CollisionModule.Systems;
using Code.CollisionModule.Utility;
using Zenject;

namespace Code.CollisionModule.Installer
{
    public class CollisionInstaller : Installer<CollisionInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CollisionPool>().AsSingle();

            Container.Bind<CollisionCleanupSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CollisionExecutor>().AsSingle();
        }
    }
}
