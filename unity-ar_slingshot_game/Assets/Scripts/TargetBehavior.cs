using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject targetPrefab;
    public int numberOfTargets = 5;
    public float minScale = 0.2f;
    public float maxScale = 0.5f;
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

    public static void SpawnTargets(int numberOfTargets, ARPlane plane)
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnPlane(plane);
            Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        }
    }
    csharp
    private Vector3 GetRandomPositionOnPlane(ARPlane plane, float margin = 0f, float padding = 0f)
    {
        Vector3 planeCenter = plane.transform.position;
        Vector3 planeExtents = new Vector3((plane.size.x / 2) - margin, 0, (plane.size.y / 2) - margin);

        // Ensure that padding does not exceed the adjusted extents
        padding = Mathf.Min(padding, planeExtents.x, planeExtents.z);

        float randomX = Random.Range(-planeExtents.x + padding, planeExtents.x - padding);
        float randomZ = Random.Range(-planeExtents.z + padding, planeExtents.z - padding);
        float yPosition = planeCenter.y;

        return new Vector3(randomX + planeCenter.x, yPosition, randomZ + planeCenter.z);
    }
}
