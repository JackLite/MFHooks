using System;
using ModulesFramework.Data;
using ModulesFramework.Modules;
using ModulesFramework.Systems;

namespace Modules.Extensions.Hooks.ModulesHooks
{
    public static class HookUtils
    {
        public static void RiseHooks<T>(this DataWorld world, Action<T> hookCall) where T : struct
        {
            foreach (var hook in world.GetRawData<T>())
            {
                hookCall(hook);
            }
        }

        public static void DestroyHooksByModule<THook, TModule>(this DataWorld world)
            where THook : struct
            where TModule : EcsModule
        {
            world.Select<THook>()
                .FromModule<TModule>()
                .DestroyAll();
        }

        public static void DestroyHooksBySystem<T>(this DataWorld world, ISystem system)
            where T : struct
        {
            world.Select<T>()
                .FromSystem(system)
                .DestroyAll();
        }

        public static void DestroyHooksBySystem<THook, TSystem>(this DataWorld world)
            where THook : struct
            where TSystem : ISystem
        {
            world.Select<THook>()
                .FromSystem<TSystem>()
                .DestroyAll();
        }

        public static Entity LinkModule<TModule>(this Entity entity) where TModule : EcsModule
        {
            return entity.AddComponent(new ModuleLink
            {
                module = entity.World.GetModule<TModule>()
            });
        }

        public static Entity LinkSystem<TSystem>(this Entity entity, TSystem system) where TSystem : ISystem
        {
            return entity.AddComponent(new SystemLink
            {
                system = system
            });
        }
    }
}