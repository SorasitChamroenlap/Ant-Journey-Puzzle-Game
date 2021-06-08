using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private bool firstTime = false;
    public GameObject [] dialogGroup;
    public GameObject loopedDialog,dialogBackgroud,continueButton,finishButton;
    private int indexCounter = 0;

    void Start(){

    }
    void Update(){
        
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
           FirstTimeChecker();      
        }
    }
    void PlayOnceDialog(){
        dialogBackgroud.SetActive(true);
        continueButton.SetActive(true);
        dialogGroup[indexCounter].SetActive(true);
    }
    void PlayLoopedDialog(){
        dialogBackgroud.SetActive(true);
        finishButton.SetActive(true);
        loopedDialog.SetActive(true);
    }
    void FirstTimeChecker(){
        if(firstTime == false){
            if(indexCounter < dialogGroup.Length){
                PlayOnceDialog();
                // indexCounter++;
            }
            else{
                firstTime = true;
            }
        }else{
            PlayLoopedDialog();
        }
    }
    public void ContinueDialog(){
        dialogBackgroud.SetActive(false);
        continueButton.SetActive(false);
        dialogGroup[indexCounter].SetActive(false);
        indexCounter++;
        FirstTimeChecker();
    }
    public void FinishDialog(){
        dialogBackgroud.SetActive(false);
        finishButton.SetActive(false);
        loopedDialog.SetActive(false);
    }
    
}
