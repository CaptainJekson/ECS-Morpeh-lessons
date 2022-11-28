using Code.BaseUtils;
using Code.CollisionModule.Installer;
using Code.PlayerModule.Configs;
using Code.PlayerModule.Systems;
using Morpeh;
using Zenject;

namespace Code.PlayerModule.Installer
{
    public class PlayerInstaller : Installer<World, int, PlayerInstaller>
    {
        private World _world;
        private int _index;

        public PlayerInstaller(World world, int index)
        {
            _world = world;
            _index = index;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromScriptableObjectResource("PlayerModule/PlayerConfig").AsSingle();

            var systemsGroup = _world.CreateSystemsGroup();

            systemsGroup.AddInitializer(Container.BindInitializer<PlayerCreateSystem>());
            systemsGroup.AddSystem(Container.BindSystem<PlayerInputSystem>());
            systemsGroup.AddSystem(Container.BindSystem<PlayerMoveSystem>());
            systemsGroup.AddSystem(Container.BindSystem<PlayerJumpSystem>());
            systemsGroup.AddSystem(Container.BindSystem<PlayerDamageSystem>());
            systemsGroup.AddSystem(Container.BindSystem<PlayerDamageCleanupSystem>());
            
            _world.AddSystemsGroup(_index, systemsGroup);
        }
    }
}