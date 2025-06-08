using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject darkBackground; // O fundo escuro

    // Função para exibir os créditos
    public void ShowCredits()
    {
        creditsPanel.SetActive(true); // Ativa o painel de créditos
        darkBackground.SetActive(true); // Ativa o fundo escuro

        // Começa o fade-in para os créditos e fundo escuro
        StartCoroutine(FadeInCredits());
    }

    // Função para esconder os créditos
    public void HideCredits()
    {
        // Começa o fade-out para os créditos e fundo escuro
        StartCoroutine(FadeOutCredits());
    }

    // Função para fazer o fade-in (tornar visível)
    private IEnumerator FadeInCredits()
    {
        float elapsedTime = 0f;
        Color creditsColor = creditsPanel.GetComponent<Image>().color;
        Color backgroundColor = darkBackground.GetComponent<Image>().color;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            creditsColor.a = Mathf.Lerp(0f, 1f, elapsedTime); // Fade-in para créditos
            backgroundColor.a = Mathf.Lerp(0f, 0.5f, elapsedTime); // Fade-in para o fundo escuro

            creditsPanel.GetComponent<Image>().color = creditsColor;
            darkBackground.GetComponent<Image>().color = backgroundColor;

            yield return null;
        }
    }

    // Função para fazer o fade-out (tornar invisível)
    private IEnumerator FadeOutCredits()
    {
        float elapsedTime = 0f;
        Color creditsColor = creditsPanel.GetComponent<Image>().color;
        Color backgroundColor = darkBackground.GetComponent<Image>().color;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            creditsColor.a = Mathf.Lerp(1f, 0f, elapsedTime); // Fade-out para créditos
            backgroundColor.a = Mathf.Lerp(0.5f, 0f, elapsedTime); // Fade-out para o fundo escuro

            creditsPanel.GetComponent<Image>().color = creditsColor;
            darkBackground.GetComponent<Image>().color = backgroundColor;

            yield return null;
        }

        creditsPanel.SetActive(false); // Desativa o painel de créditos após o fade-out
        darkBackground.SetActive(false); // Desativa o fundo escuro
    }

    // Função que pode ser chamada para pausar o jogo e mostrar o menu
    public void PauseGame()
    {
        // Pausa o jogo e mostra o menu
        Time.timeScale = 0f;
        // Coloque aqui a lógica de exibir o menu de pausa, se necessário
    }

    // Função que pode ser chamada para retomar o jogo e fechar o menu
    public void ResumeGame()
    {
        // Retoma o jogo e fecha o menu
        Time.timeScale = 1f;
        // Coloque aqui a lógica de esconder o menu de pausa, se necessário
    }

    // Função para voltar ao menu principal ou outra cena
    public void QuitGame()
    {
        Application.Quit();
    }
}
