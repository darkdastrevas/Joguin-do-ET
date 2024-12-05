using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySoundOnHover : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSound; // Som que será reproduzido
    private AudioSource audioSource;

    void Start()
    {
        // Localiza ou cria um AudioSource no mesmo objeto
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }
}