using Code.BaseInstaller;
using Code.UIModule.Systems;
using Morpeh;

namespace Code.UIModule.Installer
{
    public class UiExecutor : Executor
    {
        public UiExecutor(World world,
            UiRootCreateSystem uiRootCreateSystem) : base(world)
        {
            _initializersSystems.AddInitializer(uiRootCreateSystem);
        }
    }
}