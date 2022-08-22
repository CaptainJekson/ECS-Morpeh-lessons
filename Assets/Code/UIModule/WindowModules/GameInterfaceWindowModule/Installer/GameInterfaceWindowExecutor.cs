using Code.BaseInstaller;
using Code.UIModule.WindowModules.GameInterfaceWindowModule.Systems;
using Morpeh;

namespace Code.UIModule.WindowModules.GameInterfaceWindowModule.Installer
{
    public class GameInterfaceWindowExecutor : Executor
    {
        public GameInterfaceWindowExecutor(World world,
            GameInterfaceWindowDataSystem gameInterfaceWindowDataSystem,
            GameInterfaceWindowInitSystem gameInterfaceWindowInitSystem,
            GameInterfaceWindowInitFinishedSystem gameInterfaceWindowInitFinishedSystem,
            GameInterfaceWindowOpenPauseMenuSystem gameInterfaceWindowOpenPauseMenuSystem,
            GameInterfaceHealthBarSystem gameInterfaceHealthBarSystem) : base(world)
        {
            _updateSystems.AddSystem(gameInterfaceWindowDataSystem);
            _updateSystems.AddSystem(gameInterfaceWindowInitSystem);
            _updateSystems.AddSystem(gameInterfaceWindowInitFinishedSystem);
            _updateSystems.AddSystem(gameInterfaceWindowOpenPauseMenuSystem);
            _updateSystems.AddSystem(gameInterfaceHealthBarSystem);
        }
    }
}