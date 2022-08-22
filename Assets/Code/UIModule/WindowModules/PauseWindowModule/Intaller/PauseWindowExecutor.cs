using Code.BaseInstaller;
using Code.UIModule.WindowModules.PauseWindowModule.Systems;
using Morpeh;

namespace Code.UIModule.WindowModules.PauseWindowModule.Intaller
{
    public class PauseWindowExecutor : Executor
    {
        public PauseWindowExecutor(World world,
            PauseWindowSetDataSystem pauseWindowSetDataSystem,
            PauseWindowInitSystem pauseWindowInitSystem,
            PauseWindowInitFinishedSystem pauseWindowInitFinishedSystem,
            PauseWindowCloseSystem pauseWindowCloseSystem) : base(world)
        {
            _updateSystems.AddSystem(pauseWindowSetDataSystem);
            _updateSystems.AddSystem(pauseWindowInitSystem);
            _updateSystems.AddSystem(pauseWindowInitFinishedSystem);
            _updateSystems.AddSystem(pauseWindowCloseSystem);
        }
    }
}