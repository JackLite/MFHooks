# Hooks for Modules Framework

**Note**: this is the extension for [Modules Framework](https://github.com/JackLite/ModulesFramework) (MF).

This is an alternative way for events based on DOD and ECS. While events proceed in the definitive moment of the current or next frame hooks are proceed immediately like an usual C#'s events. But the hook is component on entity so you can use power of queries to select different types of hooks.

Here's an example:

```csharp
public struct EnemyDeadHook
{
    public Action<Entity> action;
}

public void Init() {
    // creating the hook is like creating of any other entity

    _world.NewEntity()
        .AddComponent(new EnemyDeadHook
        {
            action = OnEnemyDead
        })
        // explained below
        .LinkSystem(this);
}

private void OnEnemyDead(Entity enemy)    
{
    // will be called immediately so we may be sure that entity is still alive
}

public void Destroy() {
    // for simplify destroying there are special methods
    _world.DestroyHooksBySystem<EnemyDeadHook>(this);
}

...
    
// rising hooks
world.RiseHooks<EnemyDeadHook>(hook => hook.action(enemyEntity));
```

Like an other extensions for MF this one fully based on the core and you may repeat all this logic and expand it like you want.