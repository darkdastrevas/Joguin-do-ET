using UnityEngine;

public class controleufo : MonoBehaviour
{
    [Header("Velocidade de Movimento")]
    public float horizontalSpeed = 5f;  // Velocidade de movimento horizontal (frente/trás/esquerda/direita)
    public float verticalSpeed = 3f;    // Velocidade de movimento vertical (subir/descer)
    public float rotationSpeed = 100f; // Velocidade de rotação do drone

    private Vector3 moveDirection;

    public Animator anim;

    // REFERÊNCIAS
    [SerializeField] private Transform cameraTransform;

    public void Spawn()
        {
            anim.SetTrigger("Spawn");
        }

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

        // Calcula a direção de movimento baseada na direção da câmera
        Vector3 forward = cameraTransform.forward; // Direção para onde a câmera aponta
        Vector3 right = cameraTransform.right;     // Direção lateral da câmera

        // Ignora a inclinação da câmera para manter o movimento no plano horizontal
        forward.y = 0f;
        right.y = 0f;

        // Normaliza para evitar variação de velocidade
        forward.Normalize();
        right.Normalize();

        // Combina as entradas de movimento com as direções da câmera
        moveDirection = (forward * moveZ + right * moveX + Vector3.up * moveY).normalized;

        // Aplica o movimento
        transform.Translate(moveDirection * horizontalSpeed * Time.deltaTime, Space.World);

        // Controle da rotação (girar o drone ao redor do eixo Y)
        if (moveX != 0 || moveZ != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

       
    }
}
