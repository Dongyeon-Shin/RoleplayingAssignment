using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class _2023_06_14 : MonoBehaviour
{
    private _2023_06_14_LoadingUI loadingUI;

    private _2023_06_14_BaseScene curScene;
    public _2023_06_14_BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<_2023_06_14_BaseScene>();

            return curScene;
        }
    }

    private void Awake()
    {
        _2023_06_14_LoadingUI loadingUI = Resources.Load<_2023_06_14_LoadingUI>("UI/LoadingUI");
        this.loadingUI = Instantiate(loadingUI);
        this.loadingUI.transform.SetParent(transform);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);

        oper.allowSceneActivation = false;
        loadingUI.FadeOut();
        Time.timeScale = 0f;
        loadingUI.SetProgress(0f);

        yield return new WaitForSecondsRealtime(0.5f);

        while (oper.progress < 0.9f)
        {
            loadingUI.SetProgress(Mathf.Lerp(0f, 0.5f, oper.progress));
            yield return null;
        }
        _2023_06_14_BaseScene curScene = CurScene;
        if (curScene != null)
        {
            curScene.LoadAsync();
            while (curScene.progress < 1f)
            {
                loadingUI.SetProgress(Mathf.Lerp(0.5f, 1f, curScene.progress));
                yield return null;
            }
        }

        oper.allowSceneActivation = true;
        Time.timeScale = 1f;
        loadingUI.SetProgress(1f);
        loadingUI.FadeIn();
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
