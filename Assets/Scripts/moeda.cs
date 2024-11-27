using UnityEngine;

public class Moeda : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Encostou na Moeda");
        if (other.tag == "Player")
        {
            other.GetComponent<Jogador>().ColetarMoeda();
            Destroy(gameObject);
        }
    }
}
