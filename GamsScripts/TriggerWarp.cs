using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWarp : MonoBehaviour
{
    public GameObject summaryBox;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            summaryBox.SetActive(true);
        }
        
    }
}
