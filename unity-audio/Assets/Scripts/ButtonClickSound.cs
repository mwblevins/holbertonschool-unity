using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickSound : MonoBehaviour, IPointerClickHandler
{
    private AudioSource menuSFXAudioSource;

    private void Start()
    {
        menuSFXAudioSource = GameObject.Find("MenuSFX").GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Play the button click sound
        menuSFXAudioSource.Play();
    }
}
