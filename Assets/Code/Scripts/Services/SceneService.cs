using System;
using Cysharp.Threading.Tasks;
using Game.Interfaces.Services;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.Services
{
    /// <summary>
    /// Implementation if ISceneService
    /// </summary>
    [Preserve]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class SceneService : ISceneService
    {
        private Scene _emptyScene;

        public async UniTask<Scene> LoadSceneAsync(object sceneKey, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool activateOnLoad = true)
        {
            var scene = SceneManager.GetSceneByName(sceneKey.ToString());

            if (scene.IsValid())
                return scene.isLoaded ? scene : await LoadSceneByIndexAsync(scene.buildIndex);

            return await LoadSceneByKeyAsync(sceneKey, loadMode, activateOnLoad);
        }

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

        private async UniTask<Scene> LoadSceneByKeyAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool activateOnLoad = true)
        {
            try
            {
                var sceneInstance = await Addressables.LoadSceneAsync(key, loadMode, activateOnLoad);

                return sceneInstance.Scene;
            }
            catch (Exception _)
            {
                return _emptyScene;
            }
        }
    }
}