using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEventManager : MonoBehaviour
{
    public GameObject eventHolder,butterfly1,butterfly2;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            eventHolder.SetActive(false);
        }
        if(other.tag == "Frog"){
            butterfly1.SetActive(false);
            butterfly2.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Frog"){
            butterfly1.SetActive(true);
            butterfly2.SetActive(true);
        }
    }
}
