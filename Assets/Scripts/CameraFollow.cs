using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configura��o de Seguimento")]
    public Transform target;        // O objeto que a c�mera seguir� (UFO)
    public Vector3 offset;          // Offset da c�mera em rela��o ao UFO
    public float followSpeed = 5f;  // Velocidade do seguimento

    [Header("Configura��o de Rota��o")]
    public float rotationSpeed = 5f; // Velocidade de ajuste da rota��o

    private void LateUpdate()
    {
        if (target == null) return;

        // Atualiza a posi��o da c�mera com suaviza��o
        Vector3 targetPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Ajusta a rota��o da c�mera para alinhar com o UFO
        Quaternion targetRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}