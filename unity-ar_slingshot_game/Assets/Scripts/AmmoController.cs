using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    
    public GameObject ammo;

    void Start()
    {
        ammo.SetActive(false);
    }

    public void ShowAmmo()
    {
        ammo.SetActive(true);
    }
}
