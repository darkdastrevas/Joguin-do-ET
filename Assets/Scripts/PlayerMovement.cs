using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIAVEIS DE MOVIMENTO
    private float moveSpeed;
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.81f;

    // VARIAVEIS DE CHECAGEM
    [SerializeField] private float groundCheckDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;

    // REFERENCIAS
    private CharacterController controller;
    private Animator anim;
    [SerializeField] private Transform cameraTransform;  // Referencia da camera para o player

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Verifica��o de solo
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            velocity.y = -2f; 
        }

        // Entrada de movimento
        float moveZ = Input.GetAxis("Vertical"); // Frente e tras
        float moveX = Input.GetAxis("Horizontal"); // Esquerda e direita

        // Dire��o do movimento baseada na camera
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // Ignora a direcao vertical da camera
        camForward.y = 0;
        camRight.y = 0;

        // Deixa a camera normar
        camForward.Normalize();
        camRight.Normalize();

        // Calcula a direcao do movimento
        moveDirection = (camForward * moveZ + camRight * moveX).normalized;

        if (moveDirection.magnitude >= 0.1f)  // Verifica se tem movimento
        {
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else
            {
                Walk();
            }

            // Rotaciona o player na direcao do vetor
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // Suaviza a rotacao
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Suaviza a rota��o

            // Aplica movimento na direcao
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Idle quando n�o est� se movendo
            Idle();
        }

        // Pulo
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            Debug.Log("Pulou");
        }

        // Aplicar gravidade ao personagem
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        // Forca do pulo
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetBool("isJumping", true);
    }
}
