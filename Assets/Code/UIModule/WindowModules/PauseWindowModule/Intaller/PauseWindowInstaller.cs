using Code.UIModule.WindowModules.PauseWindowModule.Systems;
using Zenject;

namespace Code.UIModule.WindowModules.PauseWindowModule.Intaller
{
    public class PauseWindowInstaller : Installer<PauseWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PauseWindowSetDataSystem>().AsSingle();
            Container.Bind<PauseWindowInitSystem>().AsSingle();
            Container.Bind<PauseWindowInitFinishedSystem>().AsSingle();
            Container.Bind<PauseWindowCloseSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PauseWindowExecutor>().AsSingle();
        }
    }
}