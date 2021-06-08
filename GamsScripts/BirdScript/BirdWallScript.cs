using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdWallScript : MonoBehaviour
{
    public GameObject birdDialog;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            birdDialog.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
