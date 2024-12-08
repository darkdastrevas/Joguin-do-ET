using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Referência ao menu de pausa na interface

    private bool isPaused = false;

    void Update()
    {
        // Verifica se a tecla de pausa foi pressionada (Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa o tempo do jogo
        pauseMenuUI.SetActive(true); // Mostra o menu de pausa
        Cursor.lockState = CursorLockMode.None; // Libera o cursor
        Cursor.visible = true; // Torna o cursor visível
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // Retoma o tempo do jogo
        pauseMenuUI.SetActive(false); // Esconde o menu de pausa
        Cursor.lockState = CursorLockMode.Locked; // Bloqueia o cursor novamente
        Cursor.visible = false; // Esconde o cursor
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // Fecha o jogo (não funciona no editor)
    }
}
