using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodPickUp : MonoBehaviour
{
    public int Foodcount=0;
    public Text Foodamount; 
    public AudioSource foodPickupSFX;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Food"){
            DestroyFood(other);
        }
        
    }
    void DestroyFood(Collider other){
        foodPickupSFX.Play();
        Destroy(other.gameObject);  
        Foodcount += 1;
        Foodamount.text = Foodcount.ToString();
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
