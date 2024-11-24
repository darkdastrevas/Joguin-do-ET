using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    public GameObject Player; // Referência ao Alien
    public GameObject UFO; // Referência ao Drone

    public Camera Camera; // Câmera focada no Alien
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

            Camera.enabled = true;
            UFOCamera.enabled = false;
        }
        else
        {
            // Habilitar controle e câmera do Drone
            Player.GetComponent<PlayerMovement>().enabled = false;
            UFO.GetComponent<controleufo>().enabled = true;

            Camera.enabled = false;
            UFOCamera.enabled = true;
        }
    }
}