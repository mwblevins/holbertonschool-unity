using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioSource menuSFXAudioSource;
    public AudioClip rolloverClip;
    public AudioClip clickClip;

    private void Start()
    {
        // Find the MenuSFX GameObject's AudioSource
        menuSFXAudioSource = GameObject.Find("MenuSFX").GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play the button rollover sound
        menuSFXAudioSource.PlayOneShot(rolloverClip);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Play the button click sound
        menuSFXAudioSource.PlayOneShot(clickClip);
    }
}
