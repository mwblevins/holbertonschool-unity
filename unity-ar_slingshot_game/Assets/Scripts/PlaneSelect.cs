using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelect : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject targetPrefab;
    public int numberOfTargets = 5;

    public StartButtonController startButtonController;
    private bool planeSelectionDone = false;

    void Update()
    {
        if (!planeSelectionDone && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ARPlane plane = hit.transform.GetComponent<ARPlane>();

                if (plane != null)
                {
                    ARPlane[] allPlanes = FindObjectsOfType<ARPlane>();
                    foreach (ARPlane p in allPlanes)
                    {
                        p.gameObject.SetActive(false);
                    }

                    plane.gameObject.SetActive(true);
                    planeSelectionDone = true;

                    planeManager.enabled = false;
                    raycastManager.enabled = false;

                    startButtonController.ShowStartButton();

                    for (int i = 0; i < numberOfTargets; i++)
                    {
                        Vector3 randomPosition = GetRandomPositionOnPlane(plane);
                        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
                    }
                }
            }
        }
    }

    private Vector3 GetRandomPositionOnPlane(ARPlane plane)
{
    Vector3 planeCenter = plane.transform.position;
    Vector3 planeExtents = new Vector3(plane.size.x / 2, 0, plane.size.y / 2);

    float randomX = Random.Range(-planeExtents.x, planeExtents.x);
    float randomZ = Random.Range(-planeExtents.z, planeExtents.z);
    float yPosition = planeCenter.y;

    return new Vector3(randomX + planeCenter.x, yPosition, randomZ + planeCenter.z);
}
}
