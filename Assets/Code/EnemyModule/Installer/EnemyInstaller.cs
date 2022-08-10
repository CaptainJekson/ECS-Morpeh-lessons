using Code.EnemyModule.Systems;
using Zenject;

namespace Code.EnemyModule.Installer
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyCreateSystem>().AsSingle();
            Container.Bind<EnemyShootingSystem>().AsSingle();
            Container.Bind<EnemyProjectileTargetSystem>().AsSingle();
            Container.Bind<EnemyProjectileMoveSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<EnemyExecutor>().AsSingle();
        }
    }
}