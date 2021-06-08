using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barrier,bee1,bee2,bee3,dialog;
    public float bee1_posX,bee1_posY,bee1_posZ;
    public float bee2_posX,bee2_posY,bee2_posZ;
    public float bee3_posX,bee3_posY,bee3_posZ;
    public float bee1_rotX,bee1_rotY,bee1_rotZ;
    public float bee2_rotX,bee2_rotY,bee2_rotZ;
    public float bee3_rotX,bee3_rotY,bee3_rotZ;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            if(bee1 != null&&bee2 != null&&bee3 != null){
                bee1.transform.position = new Vector3(bee1_posX,bee1_posY,bee1_posZ);
                bee2.transform.position = new Vector3(bee2_posX,bee2_posY,bee2_posZ);
                bee3.transform.position = new Vector3(bee3_posX,bee3_posY,bee3_posZ);
                bee1.transform.Rotate(new Vector3(bee1_rotX,bee1_rotY,bee1_rotZ));
                bee2.transform.Rotate(new Vector3(bee2_rotX,bee2_rotY,bee2_rotZ));
                bee3.transform.Rotate(new Vector3(bee3_rotX,bee3_rotY,bee3_rotZ));
            }
            if(dialog != null){
                dialog.SetActive(true);
            }
            Destroy(barrier);
        }
    }
    public void DestroySelfe(){
        Destroy(gameObject);
    }
}
