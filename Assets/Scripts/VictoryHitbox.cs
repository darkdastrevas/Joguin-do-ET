using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trocar de cena

public class VictoryHitbox : MonoBehaviour
{
    [SerializeField] private string TelaVitoria = "TelaVitoria"; // Nome da cena de vitória

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou tem a tag "VictoryObject"
        if (other.CompareTag("VictoryObject"))
        {
            Debug.Log("Objeto de vitória detectado! Trocando para a tela de vitória...");
            LoadVictoryScene();
        }
    }

    private void LoadVictoryScene()
    {
        // Carrega a cena de vitória
        SceneManager.LoadScene(TelaVitoria);
    }
}
