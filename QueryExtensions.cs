using ModulesFramework.Data;
using ModulesFramework.Modules;
using ModulesFramework.Systems;

namespace Modules.Extensions.Hooks.ModulesHooks
{
    public static class QueryExtensions
    {
        public static DataWorld.Query FromModule<TModule>(this DataWorld.Query query) where TModule : EcsModule
        {
            return query.With<ModuleLink>()
                .Where<ModuleLink>(ml => ml.module is TModule);
        }

        public static DataWorld.Query FromSystem<TSystem>(this DataWorld.Query query) where TSystem : ISystem
        {
            return query.With<SystemLink>()
                .Where<SystemLink>(ml => ml.system is TSystem);
        }

        public static DataWorld.Query FromSystem(this DataWorld.Query query, ISystem system)
        {
            return query.With<SystemLink>()
                .Where<SystemLink>(ml => ml.system.GetType() == system.GetType());
        }
    }
}