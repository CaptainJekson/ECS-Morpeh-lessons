using Code.PlayerModule.Configs;
using Code.PlayerModule.Systems;
using Zenject;

namespace Code.PlayerModule.Installer
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromScriptableObjectResource("PlayerModule/PlayerConfig").AsSingle();
            
            Container.Bind<PlayerCreateSystem>().AsSingle();
            Container.Bind<PlayerInputSystem>().AsSingle();
            Container.Bind<PlayerMoveSystem>().AsSingle();
            Container.Bind<PlayerJumpSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerExecutor>().AsSingle();
        }
    }
}