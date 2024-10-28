using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;
    [SerializeField]private Action callback;
    [Range(0f, 1f)]
<<<<<<< Updated upstream
    public float sampleWait = 0.1f;
    private float timeWait = 0.1f;
=======
    public float sampleWait = 0.5f;
    private float timeWait = 0.5f;
>>>>>>> Stashed changes
    public float progress;


    private void Awake()
    {
        instance = this;
    }

    public void LoadSceneByName(string sceneName, Action callback)
    {
        StopCoroutine(nameof(LoadSceneProgress));
        this.callback = callback;
<<<<<<< Updated upstream
            StartCoroutine(nameof(LoadSceneProgress), sceneName);
=======
        StartCoroutine(nameof(LoadSceneProgress), sceneName);
        
>>>>>>> Stashed changes
    }

    IEnumerator LoadSceneProgress(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        float timeCount = 0;
        bool isDone = true;
        progress = 0;
        while (!isDone)
        {
            if (timeCount < timeWait)
            {
                timeCount += 0.01f;
                progress = (timeCount / timeWait) * sampleWait;
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                progress = sampleWait + async.progress * (1 - sampleWait);
            }

            isDone = async.isDone && timeCount >= timeWait;
        }
        yield return null;
        callback?.Invoke();
    }
}
