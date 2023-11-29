using ModulesFramework.Modules;

namespace Modules.Extensions.Hooks
{
    /// <summary>
    ///     Used to link some entity to module.
    ///     <para>It may be useful for hooks and similar patterns</para>
    /// </summary>
    public struct ModuleLink
    {
        public EcsModule module;
    }
}