using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject gamecamera;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera()
    {
        gamecamera.transform.position = new Vector3(player.transform.position.x,gamecamera.transform.position.y ,player.transform.position.z-10);
    }
}
