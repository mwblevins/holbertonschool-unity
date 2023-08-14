using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private GameObject player;
    public float turnSpeed = 4.0f;

    // New variable to control if the camera should be inverted
    public bool isInverted;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;

         // Load the invert option
        if (PlayerPrefs.HasKey("InvertYToggle"))
        {
            isInverted = PlayerPrefs.GetInt("InvertYToggle") == 1;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Use the isInverted bool to determine whether to invert the Mouse Y input
        float mouseY = isInverted ? -Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y");

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(mouseY * turnSpeed, Vector3.left) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }

    public void UpdateInverted()
    {
        if (PlayerPrefs.HasKey("InvertYToggle"))
            isInverted = PlayerPrefs.GetInt("InvertYToggle") == 1;
    }
}