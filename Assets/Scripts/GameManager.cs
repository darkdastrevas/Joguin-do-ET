using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    public GameObject Player; // Referência ao Alien
    public GameObject UFO; // Referência ao Drone

    public Camera PlayerCamera; // Câmera focada no Alien
    public Camera UFOCamera;    // Câmera focada no Drone

    private bool PlayerMovement = true; // Controle inicial no Alien

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Garantir que apenas o Alien esteja controlável no início
        Player.GetComponent<PlayerMovement>().enabled = true;
        UFO.GetComponent<controleufo>().enabled = false;

        // Configurar a câmera inicial
        PlayerCamera.enabled = true;
        UFOCamera.enabled = false;
    }

    void Update()
    {
        // Troca de controle com a tecla "Tab"
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchControl();
        }
    }

    public void SwitchControl()
    {
        PlayerMovement = !PlayerMovement;

        if (PlayerMovement)
        {
            // Habilitar controle e câmera do Alien
            Player.GetComponent<PlayerMovement>().enabled = true;
            UFO.GetComponent<controleufo>().enabled = false;

            PlayerCamera.enabled = true;
            UFOCamera.enabled = false;

            Debug.Log("Controle no Alien.");
        }
        else
        {
            // Habilitar controle e câmera do Drone
            Player.GetComponent<PlayerMovement>().enabled = false;
            UFO.GetComponent<controleufo>().enabled = true;

            PlayerCamera.enabled = false;
            UFOCamera.enabled = true;

            Debug.Log("Controle no Drone.");
        }
    }
}