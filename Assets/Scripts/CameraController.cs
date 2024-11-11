using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referência para o jogador
    [SerializeField] private Transform player;

    // Configurações da câmera
    [SerializeField] private float distanceFromPlayer = 5f; 
    [SerializeField] private float cameraHeight = 2f;          
    [SerializeField] private float rotationSpeed = 5f;         

    // Limites de rotação vertical
    [SerializeField] private float minVerticalAngle = -30f;    // Altura minima da camera
    [SerializeField] private float maxVerticalAngle = 60f;     // Altura maxima da camera

    // Armazena a rotação da câmera
    private float currentX = 0f;    
    private float currentY = 0f; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // Limita o angulo vertical
        currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);
    }

    private void LateUpdate()
    {
        // Calcula a direcao da camera com rotacao vertical e horizontal
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);

        // Define a posicao final da camera
        Vector3 cameraPosition = player.position + rotation * direction + Vector3.up * cameraHeight;

        // Aplica a rotacao da camera
        transform.position = cameraPosition;
        transform.LookAt(player.position + Vector3.up * cameraHeight);
    }
}
