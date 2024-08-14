using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup screen;
    [SerializeField] private Image progressBar;
    [SerializeField] private float fadeSpeed;

    public void SetProgress(float progress) => progressBar.fillAmount = Mathf.Clamp01(progress);
    public void SetProgress(AsyncOperation operation) => progressBar.fillAmount = Mathf.Clamp01(operation.progress/0.9f);

    public void Show()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn(screen));
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut(screen));
    }

    private IEnumerator FadeIn(CanvasGroup screen)
    {
        screen.alpha = 0;
        screen.gameObject.SetActive(true);

        while (screen.alpha < 1)
        {
            screen.alpha += Time.unscaledDeltaTime * fadeSpeed;
            yield return null;
        }
    }

    private IEnumerator FadeOut(CanvasGroup screen)
    {
        screen.alpha = 1;

        while (screen.alpha > 0)
        {
            screen.alpha -= Time.unscaledDeltaTime * fadeSpeed;
            yield return null;
        }

        screen.gameObject.SetActive(false);
    }
}
