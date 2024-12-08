using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Configuração de Respawn")]
    public Transform respawnPoint;  // Ponto de respawn para o jogador
    public float deathYThreshold = -10f; // Limite de altura para considerar como "queda do cenário"

    [Header("Configuração de Fade")]
    public Image fadeImage;          // Imagem preta usada para o efeito de fade
    public float fadeDuration = 1f;  // Duração do efeito de fade

    void Update()
    {
        CheckFall();
    }

    private void CheckFall()
    {
        // Verifica se o jogador caiu abaixo do limite
        if (transform.position.y < deathYThreshold)
        {
            StartCoroutine(FadeAndRespawn());
        }
    }

    private IEnumerator FadeAndRespawn()
    {
        // Ativa o fade out (tela preta)
        yield return StartCoroutine(Fade(1f));

        // Reposiciona o jogador no ponto de respawn
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        // Ativa o fade in (remove a tela preta)
        yield return StartCoroutine(Fade(0f));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a; // Opacidade atual
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);

            // Atualiza a cor da imagem
            Color color = fadeImage.color;
            color.a = newAlpha;
            fadeImage.color = color;

            yield return null;
        }

        // Garante que a opacidade final seja exatamente a desejada
        Color finalColor = fadeImage.color;
        finalColor.a = targetAlpha;
        fadeImage.color = finalColor;
    }
}
