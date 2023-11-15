using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public float minScale = 0.2f;
    public float maxScale = .5f;
    public float movementSpeed = 1.0f;
    public bool moveInXDirection = true;
    public bool moveInZDirection = true;

    private void Start()
    {
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

    private void Update()
    {
        float moveX = moveInXDirection ? Random.Range(-1f, 1f) : 0f;
        float moveZ = moveInZDirection ? Random.Range(-1f, 1f) : 0f;

        Vector3 movement = new Vector3(moveX, 0, moveZ) * movementSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
