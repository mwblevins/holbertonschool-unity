using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject CutsceneCamera;
    public GameObject MainCamera;
    public GameObject TimerCanvas;
    public GameObject TimerTrigger;

    private Animator anim;

    private void Start()
    {
        anim = Player1.GetComponent<Animator>();
        CutsceneCamera.SetActive(true);
        StartCoroutine(FinishCut());

    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(2);
        CutsceneCamera.SetActive(false);
        Player1.SetActive(true);
        Player1.GetComponent<PlayerController>().enabled = true;
        MainCamera.SetActive(true);
        TimerCanvas.SetActive(true);
        TimerTrigger.SetActive(true);
    }
}