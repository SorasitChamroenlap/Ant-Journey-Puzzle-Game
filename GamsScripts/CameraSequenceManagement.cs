using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSequenceManagement : MonoBehaviour
{
    public GameObject CutsceneCam;
    public GameObject PlayerCam;
    public GameObject SkipButton;
    public GameObject ReturnToPlayerButton;
    public GameObject Score;
    public GameObject Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunSequence());
    }
    IEnumerator RunSequence(){
        ReturnToPlayerButton.SetActive(false);
        Score.SetActive(false);
        Tutorial.SetActive(false);
        yield return new WaitForSeconds(18);
        PlayerCam.SetActive(true);
        CutsceneCam.SetActive(false);
        ReturnToPlayerButton.SetActive(true);
        Score.SetActive(true);
        Tutorial.SetActive(true);
        Destroy(SkipButton);
    }
    // Update is called once per frame
    public void SkipCutScene(){
        PlayerCam.SetActive(true);
        CutsceneCam.SetActive(false);
        Destroy(SkipButton);
        ReturnToPlayerButton.SetActive(true);
        Score.SetActive(true);
        Tutorial.SetActive(true);
    }
    void Update()
    {
        
    }
}
