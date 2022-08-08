using Zenject;

namespace Code.EnemyModule.Installer
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyExecutor>().AsSingle();
        }
    }
}