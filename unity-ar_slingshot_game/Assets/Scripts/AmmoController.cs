using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public GameObject ammo;
    public int ammoCount = 7;

    void Start()
    {
        ammo.SetActive(false);
    }
    public void ShowAmmo()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            Debug.Log("Shots remain: " + ammoCount);
            ammo.SetActive(true);
        }
        else
        {
            Debug.Log("no mas");
        }
    }
}
