using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum LoadingScene
{
    Menu,
    Loading,
    Game,
}

public class Loading : MonoBehaviour
{
    public Text Progress; // REMAKE

    private static LoadingScene _nextScene { get; set; }

    private AsyncOperation async;

    public Slider LoadProgress;

    private void Start()
    {
        StartCoroutine(LoadAsync());
    }

    private void Update()
    {
        float progress = async.progress * 100;
        Progress.text = "Loading: " + progress.ToString() + "/100";
        LoadProgress.value = progress;
    }

    private IEnumerator LoadAsync()
    {
        string scene = "Menu";

        if (_nextScene == LoadingScene.Loading)
            scene = "Game";

        async = SceneManager.LoadSceneAsync(scene);

        yield return true;
    }

    public static void Load(LoadingScene scene)
    {
        _nextScene = scene;

        SceneManager.LoadScene("Loading");
    }
}