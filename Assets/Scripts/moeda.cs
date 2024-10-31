using UnityEngine;

public class Moeda : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Teste");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Encostou na Moeda");
        other.GetComponent<Jogador>().Moeda += 1;
        Debug.Log("Moeda: " + other.GetComponent<Jogador>().Moeda);
        Destroy(gameObject);
    }
}
