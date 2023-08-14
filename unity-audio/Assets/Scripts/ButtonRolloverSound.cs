using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRolloverSound : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource menuSFXAudioSource;

    private void Start()
    {
        menuSFXAudioSource = GameObject.Find("MenuSFX").GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuSFXAudioSource.Play();
    }
}
