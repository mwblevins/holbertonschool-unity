using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
       transform.Rotate(new Vector3(45f, 0f, 0f) * Time.deltaTime); 
    }
}
