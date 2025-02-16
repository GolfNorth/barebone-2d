using Game.Interfaces.Services;
using Game.Services;
using VContainer;
using VContainer.Unity;

namespace Game.Core
{
    /// <summary>
    /// Global lifetime scope of the game.
    /// </summary>
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneService>(Lifetime.Singleton).As<ISceneService>();
            builder.Register<AudioService>(Lifetime.Singleton).As<IAudioService>();
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
