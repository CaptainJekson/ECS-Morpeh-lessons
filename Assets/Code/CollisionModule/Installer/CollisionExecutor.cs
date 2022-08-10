using Code.BaseInstaller;
using Code.CollisionModule.Systems;
using Morpeh;

namespace Code.CollisionModule.Installer
{
    public class CollisionExecutor : Executor
    {
        public CollisionExecutor(World world,
            CollisionCleanupSystem collisionCleanupSystem) : base(world)
        {
            _lateUpdateSystems.AddSystem(collisionCleanupSystem);
        }
    }
}
