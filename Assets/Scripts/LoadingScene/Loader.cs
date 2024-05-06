using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {
    public static bool isReady;

    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene {
        Level1 = 0,
        Level2 = 1,
        Level3 = 2,
        Home = 3,
        Loading = 4,
    }

    private static Action onLoaderCallback;
    public static Func<SceneMetaData> loaderMetaData;
    private static SceneMetaData loadedSceneData;
    public static SceneMetaData LoadedSceneData => loadedSceneData;
    private static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene scene) {
        SceneMetaData sceneMetaData = new SceneMetaData(scene.ToString() , (int)scene, scene);
        loadedSceneData = sceneMetaData;
        // Set the loader callback action to load the target scene
        onLoaderCallback = () => {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };
        loaderMetaData = () => {
            return sceneMetaData;
        };
        
        // Load the loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene) {
        yield return null;
        isReady = false;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        loadingAsyncOperation.allowSceneActivation = false;

        while (!loadingAsyncOperation.isDone && !isReady) {
            yield return null;
        }
        loadingAsyncOperation.allowSceneActivation = true;
    }

    public static float GetLoadingProgress() {
        if (loadingAsyncOperation != null) {
            return loadingAsyncOperation.progress;
        } else {
            return 1f;
        }
    }

    public static void LoaderCallback() {
        // Triggered after the first Update which lets the screen refresh
        // Execute the loader callback action which will load the target scene
        if (onLoaderCallback != null) {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
public class SceneMetaData
{
    public string name;
    public int ID;
    public Loader.Scene Scene;

    public SceneMetaData(string name, int iD, Loader.Scene scene)
    {
        this.name = name;
        ID = iD;
        Scene = scene;
    }
}