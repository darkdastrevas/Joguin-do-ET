using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    public GameObject Player; // Referência ao Alien
    public GameObject UFO; // Referência ao Drone
    [SerializeField] public controleufo UFOControl; // Referencia ao controle do ufo
    public PlayerMovement PlayerMovement;

    public Camera PlayerCamera; // Câmera focada no Alien
    public Camera UFOCamera;    // Câmera focada no Drone

    private bool isPlayerActive = true; // Controle inicial no Alien

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Configura estado inicial
        SetControlState(true);
    }

    void Update()
    {
        // Troca de controle ao pressionar Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchControl();
        }
    }

    public void SwitchControl()
    {
        isPlayerActive = !isPlayerActive;
        SetControlState(isPlayerActive);
    }

    private void SetControlState(bool isPlayer)
    {
        // Configura controle e câmera baseado no estado atual
        Player.GetComponent<PlayerMovement>().enabled = isPlayer;
        UFO.GetComponentInChildren<controleufo>().enabled = !isPlayer;

        PlayerCamera.enabled = isPlayer;
        UFOCamera.enabled = !isPlayer;

        // Gerencia visibilidade do UFO
        // UFO.SetActive(!isPlayer);

        if (!isPlayer)
        {
            // Posiciona o UFO acima do Player
            Vector3 playerPosition = Player.transform.position;
            UFO.transform.position = new Vector3(playerPosition.x, playerPosition.y + 5f, playerPosition.z); // Ajuste o valor de 5f para a altura desejada
        }

        Debug.Log(isPlayer ? "Controle no Alien." : "Controle no Drone.");

        UFOControl.Spawn();
    }
}
