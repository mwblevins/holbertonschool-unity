using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelect : MonoBehaviour
{
    public GameObject targetPrefab;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public Canvas startCanvas;
    private bool planeSelectionDone = false;
    public StartButtonController startButtonController;
    public AmmoController ammoController;
    public int numberOfTargets = 5;

    void Update()
    {
        if (this.enabled && !planeSelectionDone && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
                    startButtonController.ShowStartButton();
                    SpawnTargets(numberOfTargets, plane);
                    ammoController.ShowAmmo();
                    this.enabled = false;
                }
            }
        }
    }
    public void SpawnTargets(int numberOfTargets, ARPlane plane)
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnPlane(plane);
            Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        }
    }
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
