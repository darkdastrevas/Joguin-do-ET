using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configuração de Seguimento")]
    public Transform target;        // O objeto que a câmera seguirá (UFO)
    public Vector3 offset;          // Offset da câmera em relação ao UFO
    public float followSpeed = 5f;  // Velocidade do seguimento

    [Header("Configuração de Rotação")]
    public float rotationSpeed = 5f; // Velocidade de ajuste da rotação

    private void LateUpdate()
    {
        if (target == null) return;

        // Atualiza a posição da câmera com suavização
        Vector3 targetPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Ajusta a rotação da câmera para alinhar com o UFO
        Quaternion targetRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}