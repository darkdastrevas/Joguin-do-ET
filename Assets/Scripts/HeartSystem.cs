using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartSystem : MonoBehaviour
{
    // VARIÁVEIS
    public int vidaMax;
    public int vidaAtual;

    public Image[] heart;
    public Sprite cheio;
    public Sprite vazio;

    private Animator anim;

    [SerializeField] private Image fadeImage; // Imagem para o fade in/out
    [SerializeField] private float fadeDuration = 1.0f; // Duração do fade
    [SerializeField] private Transform startPoint; // Ponto inicial para resetar o personagem

    [SerializeField] private PlayerMovement PlayerMovement;

    private bool isFading = false;

    void Start()
    {
        vidaAtual = vidaMax;
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, 0); // Começa transparente
        }
    }

    void Update()
    {
        HealthLogic();

        if (vidaAtual <= 0 && !isFading) // Quando a vida chega a 0
        {
            StartCoroutine(HandleDeath());
        }
    }

    // LÓGICA DA VIDA
    void HealthLogic()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            // TROCAR DE SPRITE
            if (i < vidaAtual)
            {
                heart[i].sprite = cheio;
            }
            else
            {
                heart[i].sprite = vazio;
            }
            // PERDER-GANHAR VIDA
            if (i < vidaMax)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }

    

    // COROUTINE PARA FADE E RESET
    private IEnumerator HandleDeath()
    {
        isFading = true;

        // Fade Out (para preto)
        yield return StartCoroutine(Fade(1));

        // Resetar posição e vida
        transform.parent.position = startPoint.position;
        vidaAtual = vidaMax;

        // Fade In (de volta à cena)
        yield return StartCoroutine(Fade(0));

        isFading = false;
        PlayerMovement.isAlive = true;
        PlayerMovement.Revive();

    }

    // Função de fade genérica
    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, targetAlpha);
    }
}
