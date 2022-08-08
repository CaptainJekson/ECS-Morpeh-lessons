using System;
using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.BaseInstaller
{
    public abstract class Executor : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        protected readonly World _world;
        protected readonly SystemsGroup _initializersSystems;
        protected readonly SystemsGroup _updateSystems;
        protected readonly SystemsGroup _fixedUpdateSystems;
        protected readonly SystemsGroup _lateUpdateSystems;

        protected Executor(World world)
        {
            _world = world;

            _initializersSystems = _world.CreateSystemsGroup();
            _updateSystems = world.CreateSystemsGroup();
            _fixedUpdateSystems = _world.CreateSystemsGroup();
            _lateUpdateSystems = world.CreateSystemsGroup();
        }
        
        public void Initialize()
        {
            _initializersSystems.Initialize();
            _updateSystems.Initialize();
            _fixedUpdateSystems.Initialize();
            _lateUpdateSystems.Initialize();
        }

        public void Tick()
        {
            _updateSystems.Update(Time.deltaTime);
        }

        public void FixedTick()
        {
            _fixedUpdateSystems.FixedUpdate(Time.fixedDeltaTime);
        }

        public void LateTick()
        {
            _lateUpdateSystems.LateUpdate(Time.deltaTime);
        }

        public void Dispose()
        {
            _initializersSystems.Dispose();
            _updateSystems.Dispose();
            _fixedUpdateSystems.Dispose();
            _lateUpdateSystems.Dispose();
        }
    }
}
