using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            heart.vidaAtual--;
        }
    }

}
