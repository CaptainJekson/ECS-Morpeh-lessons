using Code.UIModule.Configs;
using Code.UIModule.Systems;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Installer;
using Code.UIModule.WindowModules.PauseWindowModule.Intaller;
using Zenject;

namespace Code.UIModule.Installer
{
    public class UiInstaller : Installer<UiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UiRootConfig>().FromScriptableObjectResource("UIModule/UiRootConfig").AsSingle();
            
            Container.Bind<UiRootCreateSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<UiExecutor>().AsSingle();
            
            GameInterfaceWindowInstaller.Install(Container);
            PauseWindowInstaller.Install(Container);
        }
    }
}