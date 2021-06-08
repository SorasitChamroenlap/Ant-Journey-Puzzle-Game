using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorialsdetail : MonoBehaviour
{
    public GameObject tutorialDetail;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){}
        tutorialDetail.SetActive(true);
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
