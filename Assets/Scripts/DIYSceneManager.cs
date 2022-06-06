using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DIYSceneManager : MonoBehaviour
{
    public static DIYSceneManager singleton { get; private set; }

    public AsyncOperation async;
    public string SceneName;
    public string LoadingScene;

    private void Start()
    {
        SceneManager_Init();
    }

    public virtual void SceneManager_Init()
    {
        singleton = this;
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneName">加载的场景的名称(需要已添加至Build)</param>
    /// <param name="leastTimeToNewScene">加载场景至少需要等待的时间(秒)</param>
    /// <param name="Load_SceneName">Load场景的名字</param>
    public void LoadScene(string sceneName = "",string Load_SceneName = "Loading",float leastTimeToNewScene = 1f)
    {
        if (sceneName == "")
        {
            Debug.LogError("sceneName is null!");
        }
        else
        {
            StartCoroutine(LoadSceneAsync(sceneName, Load_SceneName, leastTimeToNewScene));
        }
    }
    //注意！开启这个协程会把前一个DIYSceneManager的加载协程顶掉重新创建一个。
    IEnumerator LoadSceneAsync(string sceneName, string Load_SceneName, float leastTimeToNewScene)
    {
        float time = 0;

        if(Load_SceneName!="")
        {
            SceneManager.LoadScene(Load_SceneName);
        }
        yield return new WaitForSecondsRealtime(0.1f);
        async = null;
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        Debug.Log("Now Loading: " + sceneName);
        while (!async.isDone)
        {
            time += 0.5f;
            // Check if the load has finished
            if (async.progress >= 0.9f)
            {
                if (time >= leastTimeToNewScene)
                {
                    async.allowSceneActivation = true;
                    async = null;
                    break;
                }
            }
            yield return new WaitForSeconds(0.5f); ;
        }
        yield return null;
    }
}
