using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEventManager : MonoBehaviour
{
    public GameObject eventStarter,newWorm,worm,birdWall,birdNestDialog;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(worm.activeSelf == true){
                birdNestDialog.SetActive(true);
            }else{
                eventStarter.SetActive(true);
                newWorm.SetActive(true);
                birdWall.SetActive(false);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
