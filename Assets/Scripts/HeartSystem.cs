using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
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

    void HealthLogic()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < vidaAtual)
            {
                heart[i].sprite = cheio;
            }
            else
            {
                heart[i].sprite = vazio;
            }
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
