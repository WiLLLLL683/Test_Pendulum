using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public LoadScreenUI loadScreenUI;

        public void UnloadScene(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            if (scene.isLoaded)
                SceneManager.UnloadSceneAsync(scene);
        }

        public void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive, bool showLoadScreen = true)
        {
            StartCoroutine(LoadRoutine(sceneName, mode, showLoadScreen));
        }

        public IEnumerator LoadRoutine(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive, bool showLoadScreen = true)
        {
            if (showLoadScreen)
            {
                yield return loadScreenUI.Show();
            }

            //загрузка сцены
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, mode);
            operation.allowSceneActivation = false;
            while (!operation.isDone)
            {
                loadScreenUI.SetProgress(operation.progress / 0.9f);

                if (operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }

            //активация сцены
            Scene scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(scene);

            if (showLoadScreen)
            {
                yield return loadScreenUI.Hide();
            }

            Debug.Log($"<b><color=cyan>{sceneName} is loaded</color></b>", this);
        }
    }
}