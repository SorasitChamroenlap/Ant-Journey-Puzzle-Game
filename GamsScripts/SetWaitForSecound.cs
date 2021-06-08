using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaitForSecound : MonoBehaviour
{
    public GameObject targetObject;
    public int waitTime;
    // Start is called before the first frame update
   
    void Start()
    {
        StartCoroutine(WaitFor());
    }
    IEnumerator WaitFor(){
        yield return new WaitForSeconds(waitTime);
        targetObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
