using UnityEngine;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nome da cena para carregar
    [SerializeField] private SceneTransition sceneTransition;  // Referência ao SceneTransition

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o player colidiu
        if (other.CompareTag("Player"))
        {
            sceneTransition.TransitionToScene(sceneName); // Usa a função do SceneTransition
        }
    }
}
