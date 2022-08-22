using Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems;
using Zenject;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Installer
{
    public class GameInterfaceWindowInstaller : Installer<GameInterfaceWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameInterfaceWindowDataSystem>().AsSingle();
            Container.Bind<GameInterfaceWindowInitSystem>().AsSingle();
            Container.Bind<GameInterfaceWindowInitFinishedSystem>().AsSingle();
            Container.Bind<GameInterfaceWindowOpenPauseMenuSystem>().AsSingle();
            Container.Bind<GameInterfaceHealthBarSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameInterfaceWindowExecutor>().AsSingle();
        }
    }
}