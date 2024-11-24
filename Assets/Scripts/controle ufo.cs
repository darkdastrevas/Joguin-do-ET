using UnityEngine;

public class controleufo : MonoBehaviour
{
    [Header("Velocidade de Movimento")]
    public float horizontalSpeed = 5f;  // Velocidade de movimento horizontal (frente/trás/esquerda/direita)
    public float verticalSpeed = 3f;    // Velocidade de movimento vertical (subir/descer)
    public float rotationSpeed = 100f; // Velocidade de rotação do drone

    private Vector3 moveDirection;

    void Update()
    {
        // Controle do movimento horizontal
        float moveX = Input.GetAxis("Horizontal"); // Esquerda/Direita
        float moveZ = Input.GetAxis("Vertical");   // Frente/Trás

        // Controle do movimento vertical (Subir/Descer)
        float moveY = 0;
        if (Input.GetKey(KeyCode.Space)) // Subir
            moveY = 1;
        else if (Input.GetKey(KeyCode.LeftShift)) // Descer
            moveY = -1;

        // Combina as direções de movimento
        moveDirection = new Vector3(moveX, moveY * verticalSpeed, moveZ).normalized;

        // Aplica o movimento
        transform.Translate(moveDirection * horizontalSpeed * Time.deltaTime, Space.World);

        // Controle da rotação (girar o drone ao redor do eixo Y)
        float rotationInput = Input.GetAxis("Mouse X"); // Input para girar com o mouse
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
    }
}