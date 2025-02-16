using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Interfaces.Services;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.Services
{
    /// <summary>
    /// Implementation of ISceneService
    /// </summary>
    [Preserve]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class SceneService : ISceneService
    {
        private Scene _emptyScene;

        private readonly Dictionary<string, SceneInstance> _sceneInstances = new();

        public async UniTask<Scene> LoadSceneAsync(object sceneKey, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool activateOnLoad = true)
        {
            var sceneBuildIndex = GetSceneBuildIndex(sceneKey.ToString());

            return sceneBuildIndex >= 0
                ? await LoadSceneByIndexAsync(sceneBuildIndex, loadMode, activateOnLoad)
                : await LoadSceneByKeyAsync(sceneKey, loadMode, activateOnLoad);
        }

        public async UniTask UnloadSceneAsync(string sceneName)
        {
            if (_sceneInstances.TryGetValue(sceneName, out var sceneInstance))
            {
                await Addressables.UnloadSceneAsync(sceneInstance);

                return;
            }

            await SceneManager.UnloadSceneAsync(sceneName).ToUniTask();
        }

        /// <summary>
        /// Gets the build index of a scene based on its name.
        /// </summary>
        /// <param name="sceneName">The name of the scene.</param>
        /// <returns>The build index of the scene, or -1 if not found.</returns>
        private static int GetSceneBuildIndex(string sceneName)
        {
            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if (SceneUtility.GetScenePathByBuildIndex(i).Contains(sceneName))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Loads a scene asynchronously based on its build index.
        /// </summary>
        /// <param name="sceneBuildIndex">The build index of the scene to load.</param>
        /// <param name="loadMode">The mode in which to load the scene.</param>
        /// <param name="activateOnLoad">Whether to activate the scene on load.</param>
        private async UniTask<Scene> LoadSceneByIndexAsync(int sceneBuildIndex,
            LoadSceneMode loadMode = LoadSceneMode.Single, bool activateOnLoad = true)
        {
            var operation = SceneManager.LoadSceneAsync(sceneBuildIndex, loadMode);

            if (operation == null)
                return _emptyScene;

            operation.allowSceneActivation = activateOnLoad;

            await operation.ToUniTask();

            return SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
        }

        /// <summary>
        /// Loads a scene asynchronously based on its key.
        /// </summary>
        /// <param name="key">The key of the scene to load.</param>
        /// <param name="loadMode">The mode in which to load the scene.</param>
        /// <param name="activateOnLoad">Whether to activate the scene on load.</param>
        private async UniTask<Scene> LoadSceneByKeyAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool activateOnLoad = true)
        {
            try
            {
                var sceneInstance = await Addressables.LoadSceneAsync(key, loadMode, activateOnLoad);

                _sceneInstances.TryAdd(sceneInstance.Scene.name, sceneInstance);

                return sceneInstance.Scene;
            }
            catch (Exception)
            {
                return _emptyScene;
            }
        }
    }
}