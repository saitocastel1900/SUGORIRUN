using System;
using Zenject;

/// <summary>
/// IInputEventProviderを注入する
/// </summary>
public class InputEventInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IInputEventProvider),
                typeof(IInitializable), typeof(IDisposable))
            .To<KeyInputProvider>().AsSingle();
    }
}