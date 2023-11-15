using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private Rigidbody rb;
    private bool isShoot;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTouchStart(touch.position);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                OnTouchEnd(touch.position);
            }
        }
    }

    private void OnTouchStart(Vector3 touchPosition)
    {
        touchStartPos = touchPosition;
    }

    private void OnTouchEnd(Vector3 touchPosition)
    {
        touchEndPos = touchPosition;
        Shoot(force: touchEndPos - touchStartPos);
    }

    private float forceMultiplier = 1;

    void Shoot(Vector3 force)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(force.x, force.y, z: force.y) * forceMultiplier);
        isShoot = true;
    }
}
