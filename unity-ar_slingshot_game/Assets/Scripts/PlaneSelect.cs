using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelect : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public Canvas startCanvas;
    private bool planeSelectionDone = false;
    public StartButtonController startButtonController;
    public AmmoController ammoController;
    private bool planeSelectEnabled = true;

    void Update()
    {
        if (planeSelectEnabled && !planeSelectionDone && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
                    StartButtonController.ShowStartButton();
                    TargetBehavior.SpawnTargets();
                    AmmoController.ShowAmmo();
                    planeSelectEnabled = false;
                }
            }
        }
    }
}
