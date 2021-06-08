using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    public float panSpeed = 50f;
    public float panBoarderThickness = 10f;
    public float scrollSpeed = 50f;
    public float minY = 10f;
    public float maxY = 50f;
    public float panLimit_X_pos;
    public float panLimit_X_neg;
    public float panLimit_Y_pos;
    public float panLimit_Y_neg;
    public bool toggleMouseSwitch = false;
    void Update(){
        Vector3 pos = transform.position;
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            if(toggleMouseSwitch == false){
                toggleMouseSwitch = true;
            }else{
                toggleMouseSwitch = false;
            }
        }

        if(toggleMouseSwitch == false){
            if(Input.GetKey("w")){
                pos.z += panSpeed*Time.deltaTime;
            }
            if(Input.GetKey("s")){
                pos.z -= panSpeed*Time.deltaTime;
            }
            if(Input.GetKey("d")){
                pos.x += panSpeed*Time.deltaTime;
            }
            if(Input.GetKey("a")){
                pos.x -= panSpeed*Time.deltaTime;
            }
        }
        if(toggleMouseSwitch == true){
            if(Input.mousePosition.y >= Screen.height - panBoarderThickness){
                pos.z += panSpeed*Time.deltaTime;
            }
            if(Input.mousePosition.y <= panBoarderThickness){
                pos.z -= panSpeed*Time.deltaTime;
            }
            if(Input.mousePosition.x >= Screen.width - panBoarderThickness){
                pos.x += panSpeed*Time.deltaTime;
            }
            if(Input.mousePosition.x <= panBoarderThickness){
                pos.x -= panSpeed*Time.deltaTime;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll*scrollSpeed*200f*Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.x = Mathf.Clamp(pos.x, panLimit_X_neg, panLimit_X_pos);
        pos.z = Mathf.Clamp(pos.z, panLimit_Y_neg, panLimit_Y_pos);        

        transform.position = pos;
    }    

}
