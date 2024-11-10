using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIÁVEIS DE MOVIMENTO
    private float moveSpeed;
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.81f;

    // VARIÁVEIS DE CHECAGEM
    [SerializeField] private float groundCheckDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;

    // REFERÊNCIA
    private CharacterController controller;
    private Animator anim;

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
       
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            velocity.y = -2f;  
        }

        // Entrada de movimento
        float moveZ = Input.GetAxis("Vertical"); // Frente e trás
        float moveX = Input.GetAxis("Horizontal"); // Esquerda e direita

        // Direção do movimento
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Rotaciona o jogador
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Suaviza a rotação
        }

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                // Andar
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                // Correr
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                // Idle
                Idle();
            }

            // Aplica movimentação na direção do jogador
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
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
        // Força do pulo
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetBool("isJumping", true);
    }
}
