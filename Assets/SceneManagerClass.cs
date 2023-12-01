using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerClass : MonoBehaviour
{
    public float progress;
    public void LoadScene(string scenename)
    {
        StartCoroutine(LoadSceneGame(scenename));
    }
    IEnumerator LoadSceneGame(string scenename)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scenename, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            progress = Mathf.Clamp01(async.progress / 0.9f);
            if (progress == 1f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
