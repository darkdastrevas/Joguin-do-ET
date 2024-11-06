using UnityEngine;
using TMPro;
public class Jogador : MonoBehaviour
{
    public int Moeda = 0;
    public TMP_Text MoedaHUD;

    public void ColetarMoeda()
    {
        Moeda++;
        AtualizarHUD();
    }
    public void AtualizarHUD()
    {
        MoedaHUD.text = Moeda.ToString();
    }
}
