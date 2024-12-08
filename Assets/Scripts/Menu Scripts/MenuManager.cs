using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject darkBackground; // O fundo escuro

    // Fun��o para exibir os cr�ditos
    public void ShowCredits()
    {
        creditsPanel.SetActive(true); // Ativa o painel de cr�ditos
        darkBackground.SetActive(true); // Ativa o fundo escuro

        // Come�a o fade-in para os cr�ditos e fundo escuro
        StartCoroutine(FadeInCredits());
    }

    // Fun��o para esconder os cr�ditos
    public void HideCredits()
    {
        // Come�a o fade-out para os cr�ditos e fundo escuro
        StartCoroutine(FadeOutCredits());
    }

    // Fun��o para fazer o fade-in (tornar vis�vel)
    private IEnumerator FadeInCredits()
    {
        float elapsedTime = 0f;
        Color creditsColor = creditsPanel.GetComponent<Image>().color;
        Color backgroundColor = darkBackground.GetComponent<Image>().color;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            creditsColor.a = Mathf.Lerp(0f, 1f, elapsedTime); // Fade-in para cr�ditos
            backgroundColor.a = Mathf.Lerp(0f, 0.5f, elapsedTime); // Fade-in para o fundo escuro

            creditsPanel.GetComponent<Image>().color = creditsColor;
            darkBackground.GetComponent<Image>().color = backgroundColor;

            yield return null;
        }
    }

    // Fun��o para fazer o fade-out (tornar invis�vel)
    private IEnumerator FadeOutCredits()
    {
        float elapsedTime = 0f;
        Color creditsColor = creditsPanel.GetComponent<Image>().color;
        Color backgroundColor = darkBackground.GetComponent<Image>().color;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            creditsColor.a = Mathf.Lerp(1f, 0f, elapsedTime); // Fade-out para cr�ditos
            backgroundColor.a = Mathf.Lerp(0.5f, 0f, elapsedTime); // Fade-out para o fundo escuro

            creditsPanel.GetComponent<Image>().color = creditsColor;
            darkBackground.GetComponent<Image>().color = backgroundColor;

            yield return null;
        }

        creditsPanel.SetActive(false); // Desativa o painel de cr�ditos ap�s o fade-out
        darkBackground.SetActive(false); // Desativa o fundo escuro
    }

    // Fun��o que pode ser chamada para pausar o jogo e mostrar o menu
    public void PauseGame()
    {
        // Pausa o jogo e mostra o menu
        Time.timeScale = 0f;
        // Coloque aqui a l�gica de exibir o menu de pausa, se necess�rio
    }

    // Fun��o que pode ser chamada para retomar o jogo e fechar o menu
    public void ResumeGame()
    {
        // Retoma o jogo e fecha o menu
        Time.timeScale = 1f;
        // Coloque aqui a l�gica de esconder o menu de pausa, se necess�rio
    }

    // Fun��o para voltar ao menu principal ou outra cena
    public void QuitGame()
    {
        Application.Quit();
    }
}
