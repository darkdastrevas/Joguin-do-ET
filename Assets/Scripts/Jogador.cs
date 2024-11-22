using UnityEngine;
using TMPro;
public class Jogador : MonoBehaviour
{
    public int Moeda = 0;
    public TMP_Text MoedaHUD;
    private Animator anim;
    private HeartSystem heartSystem;
    private int vidaAnterior;

    public void ColetarMoeda()
    {
        Moeda++;
        AtualizarHUD();
    }
    public void AtualizarHUD()
    {
        MoedaHUD.text = Moeda.ToString();
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        heartSystem = GetComponentInChildren<HeartSystem>();

        if (heartSystem != null)
        {
            vidaAnterior = heartSystem.vidaAtual;
        }
    }

    private void Update()
    {
        
    }
}
