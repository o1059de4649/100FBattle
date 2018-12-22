using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class LoadingScene : MonoBehaviour
    {

        private AsyncOperation async;
        public GameObject LoadingUi;
        public Slider Slider;

        public void LoadNextScene()
        {
            LoadingUi.SetActive(true);
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            async = SceneManager.LoadSceneAsync("Main");

            while (!async.isDone)
            {
                Slider.value = async.progress;
                yield return null;
            }
        }
    }
}