using UnityEngine;

public class DroneAbduction : MonoBehaviour
{
    [SerializeField] private Transform abductionPoint; // Ponto onde o objeto será levitado
    [SerializeField] private float liftSpeed = 5f; // Velocidade de levitação
    [SerializeField] private float detectionRadius = 5f; // Raio de detecção da abdução
    [SerializeField] private LayerMask abductionLayer; // Layer para objetos que podem ser abduzidos

    private GameObject abductedObject; // Objeto atualmente sendo abduzido
    private bool isAbducting = false; // Controle da abdução
    private Collider abductedObjectCollider; // Collider do objeto abduzido

    private Collider droneCollider; // Collider do drone

    void Start()
    {
        // Configuração do droneCollider
        droneCollider = GetComponent<Collider>();
        if (droneCollider != null)
        {
            // Certificar que o collider do drone seja um Trigger para não bloquear o personagem
            droneCollider.isTrigger = true;
        }

        // Ignorar colisões entre a camada "Drone" e a camada "Player"
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("UFO"), LayerMask.NameToLayer("Player"), true);
    }

    void Update()
    {
        // Controle de entrada para abduzir ou liberar
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (abductedObject == null)
            {
                TryToAbduct();
            }
            else
            {
                ReleaseObject();
            }
        }

        // Levitação do objeto
        if (isAbducting && abductedObject != null)
        {
            LevitateObject();
        }
    }

    private void TryToAbduct()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, abductionLayer);

        if (colliders.Length > 0)
        {
            // Pegue o primeiro objeto no raio
            abductedObject = colliders[0].gameObject;
            abductedObjectCollider = abductedObject.GetComponent<Collider>();

            // Desabilitar gravidade para o objeto
            Rigidbody rb = abductedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = true; // Previne interferência física
            }

            // Ignorar colisões entre o drone e o objeto abduzido
            if (droneCollider != null && abductedObjectCollider != null)
            {
                Physics.IgnoreCollision(droneCollider, abductedObjectCollider, true);
            }

            isAbducting = true;
        }
    }

    private void LevitateObject()
    {
        if (abductedObject != null)
        {
            abductedObject.transform.position = Vector3.MoveTowards(
                abductedObject.transform.position,
                abductionPoint.position,
                liftSpeed * Time.deltaTime
            );
        }
    }

    private void ReleaseObject()
    {
        if (abductedObject != null)
        {
            // Reabilitar gravidade e liberar o objeto
            Rigidbody rb = abductedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.linearVelocity = Vector3.zero; // Remove forças residuais
                rb.angularVelocity = Vector3.zero;
            }

            // Reativar colisões entre o drone e o objeto
            if (droneCollider != null && abductedObjectCollider != null)
            {
                Physics.IgnoreCollision(droneCollider, abductedObjectCollider, false);
            }

            abductedObject = null;
            abductedObjectCollider = null;
            isAbducting = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar o raio de detecção no Editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}