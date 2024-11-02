using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    // VARIÁVEIS
    public int vidaMax;
    public int vidaAtual;

    public Image[] heart;
    public Sprite cheio;
    public Sprite vazio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
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
}
