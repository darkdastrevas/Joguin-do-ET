using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadePanel; // Referencia imagem usada para o fade
    public float fadeDuration = 1f; // Duracao do fade

    private void Start()
    {
        // Inicia com o Fade In ao carregar a cena
        StartCoroutine(FadeIn());
    }

    public void TransitionToScene(string sceneName)
    {
        // Comeca o Fade Out e, em seguida, carrega a proxima cena
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadePanel.color;
        fadeColor.a = 1f; // Comeca totalmente opaco

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadePanel.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 0f;
        fadePanel.color = fadeColor;
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float elapsedTime = 0f;
        Color fadeColor = fadePanel.color;
        fadeColor.a = 0f; // Comeca transparente

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadePanel.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 1f;
        fadePanel.color = fadeColor;

        // Carrega a próxima cena
        SceneManager.LoadScene(sceneName);
    }
}
