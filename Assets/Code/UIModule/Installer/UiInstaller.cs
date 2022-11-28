using Code.UIModule.Configs;
using Code.UIModule.Systems;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Installer;
using Code.UIModule.WindowModules.PauseWindowModule.Intaller;
using Morpeh;
using Zenject;

namespace Code.UIModule.Installer
{
    public class UiInstaller : Installer<World, int, UiInstaller>
    {
        private World _world;
        private int _index;
        
        public UiInstaller(World world, int index)
        {
            _world = world;
            _index = index;
        }

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