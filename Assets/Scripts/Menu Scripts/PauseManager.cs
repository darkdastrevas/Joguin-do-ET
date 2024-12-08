using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Painel do menu de pausa
    public GameObject extraImage; // Imagem extra para exibir no botão

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isPaused && extraImage.activeSelf)
            {
                // Fecha a imagem extra
                extraImage.SetActive(false);
            }
            else
            {
                // Alterna o estado de pausa
                TogglePause();
            }
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f; // Pausa/Despausa o jogo

        Cursor.visible = isPaused; // Mostra o cursor quando pausado
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked; // Desbloqueia o cursor quando pausado
    }

    public void ShowImage()
    {
        if (!extraImage.activeSelf)
        {
            extraImage.SetActive(true); // Mostra a imagem
        }
    }
}