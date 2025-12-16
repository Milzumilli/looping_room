using UnityEngine;
using TMPro;
using System.Collections;

public class FadeInText : MonoBehaviour
{
    public float fadeDuration = 1f;
    TMP_Text text;

    void Awake()
    {
        // Hakee tekstin myös lapsiobjekteista (myös inactive)
        text = GetComponent<TMP_Text>();
        if (text == null) text = GetComponentInChildren<TMP_Text>(true);

        if (text == null)
            Debug.LogError("FadeInText: TMP_Text not found on this object or children!");
    }

    public void PlayFadeIn()
    {
        Debug.Log("text is null? " + (text == null));

        Debug.Log("FadeInText: PlayFadeIn() called on " + gameObject.name);

        if (text == null) return;

        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        Color c = text.color;
        c.a = 0f;
        text.color = c;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            text.color = c;
            
            text.canvasRenderer.SetAlpha(c.a);

            yield return null;
        }

        c.a = 1f;
        text.color = c;
        text.canvasRenderer.SetAlpha(1f);
    }
}
