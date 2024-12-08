using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public float fallThreshold = -10f;

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.Sleep(); // Reseta o movimento e rotação do Rigidbody de forma segura
        }
    }
}
