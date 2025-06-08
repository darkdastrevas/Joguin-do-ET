using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource footstepAudioSource;  // Fonte de �udio dos passos
    [SerializeField] private AudioClip[] footstepSounds;      // Sons dos passos
    [SerializeField] private LayerMask groundLayer;           // Camada de ch�o para identificar o tipo de terreno
    [SerializeField] private float stepInterval = 0.5f;       // Intervalo entre os passos

    private float stepTimer;                                 // Timer para o intervalo entre os passos
    private CharacterController characterController;          // Controlador do jogador
    private bool isWalking;                                  // Verifica se o jogador est� andando
    private bool isAudioPlaying = false;                      // Flag para controlar a reprodu��o do �udio

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        stepTimer = stepInterval;  // Inicializa o timer do passo
    }

    private void Update()
    {
        // Verifica se o jogador est� se movendo (n�o est� parado) e se est� tocando o ch�o
        isWalking = characterController.isGrounded && characterController.velocity.magnitude > 0.1f;

        // Verifica se o jogador est� caminhando e se o �udio n�o est� tocando
        if (isWalking && !isAudioPlaying)
        {
            stepTimer -= Time.deltaTime;

            // Reproduz o som de passo quando o intervalo expira
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = stepInterval; // Reseta o temporizador
            }
        }
        else if (!isWalking)  // Se o jogador n�o estiver se movendo, reseta o temporizador
        {
            stepTimer = stepInterval;
        }
    }

    private void PlayFootstepSound()
    {
        // Seleciona um som aleat�rio da lista de sons de passos
        AudioClip clipToPlay = footstepSounds[Random.Range(0, footstepSounds.Length)];
        footstepAudioSource.PlayOneShot(clipToPlay);
        isAudioPlaying = true;

        // Quando o �udio terminar, resetar a flag
        StartCoroutine(ResetAudioFlag(clipToPlay.length));
    }

    private IEnumerator ResetAudioFlag(float audioLength)
    {
        // Espera o tempo do �udio tocar completamente
        yield return new WaitForSeconds(audioLength);
        isAudioPlaying = false;  // Permite tocar o pr�ximo som de passo
    }
}
