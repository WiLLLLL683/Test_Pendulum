﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup screen;
    [SerializeField] private Image progressBar;
    [SerializeField] private float fadeSpeed;

    public void SetProgress(float progress)
    {
        if (progressBar == null)
            return;

        progressBar.fillAmount = Mathf.Clamp01(progress);
    }

    public IEnumerator Show()
    {
        StopAllCoroutines();
        yield return FadeIn(screen);
    }

    public IEnumerator Hide()
    {
        StopAllCoroutines();
        yield return FadeOut(screen);
    }

    private IEnumerator FadeIn(CanvasGroup screen)
    {
        screen.interactable = true;

        while (screen.alpha < 1)
        {
            screen.alpha += Time.unscaledDeltaTime * fadeSpeed;
            yield return null;
        }
    }

    private IEnumerator FadeOut(CanvasGroup screen)
    {
        while (screen.alpha > 0)
        {
            screen.alpha -= Time.unscaledDeltaTime * fadeSpeed;
            yield return null;
        }

        screen.interactable = false;
    }
}
