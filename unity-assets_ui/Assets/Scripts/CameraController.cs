using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float rotationSpeed = 2f;
    public bool isInverted = false;
    public float minY = 0f;

    private Vector3 offset;
    private bool isRotating;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        // Camera follow
        Vector3 targetPosition = player.position + offset;
        targetPosition.y = Mathf.Max(targetPosition.y, minY);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Camera rotation
        if (Input.GetMouseButton(1))
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * (isInverted ? -1 : 1);
            Vector3 eulerAngleDelta = new Vector3(0f, 0f, mouseY);
            Quaternion rotationDelta = Quaternion.Euler(eulerAngleDelta);
            transform.rotation *= rotationDelta;
        }
    }
}
