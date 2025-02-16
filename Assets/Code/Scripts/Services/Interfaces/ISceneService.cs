using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Interfaces.Services
{
    /// <summary>
    /// Interface for scene services.
    /// </summary>
    public interface ISceneService
    {
        /// <summary>
        /// Loads the Scene asynchronously in the background.
        /// </summary>
        /// <param name="sceneKey">The key of the location of the scene to load.</param>
        /// <param name="loadMode">Scene load mode.</param>
        /// <param name="activateOnLoad">If false, the scene will load but not activate (for background loading).</param>
        UniTask<Scene> LoadSceneAsync(object sceneKey, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool activateOnLoad = true);

        /// <summary>
        /// Destroys all GameObjects associated with the given Scene and removes the Scene.
        /// </summary>
        /// <param name="sceneName">Name or path of the Scene to unload.</param>
        UniTask UnloadSceneAsync(string sceneName);
    }
}