using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset = new Vector3(0f, 20f, -10f);
    // Update is called once per frame
    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + cameraOffset;
        }
    }
}
