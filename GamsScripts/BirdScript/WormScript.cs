using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormScript : MonoBehaviour
{
    public AudioSource foodPickupSound;
    public GameObject eggUI;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            gameObject.SetActive(false);
            foodPickupSound.Play();
            eggUI.SetActive(true);
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
