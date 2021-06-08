using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestinationScript : MonoBehaviour
{
    public GameObject dialoagBackground1,dialoagBackground2,anotherAnt,anotherAntWall,
    P1text1,P1text2,P1text3,P1text4,P1text5,P1text6,P2text1,P2text2,P2text3,P2text4;
    public float waitTime;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            dialoagBackground1.SetActive(true);
            StartCoroutine(WaitFor());
        }
    }       
    IEnumerator WaitFor(){
        yield return new WaitForSeconds(waitTime);
        dialoagBackground1.SetActive(true);
        P1text1.SetActive(false);
        P1text2.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        anotherAnt.SetActive(true);//
        P1text2.SetActive(false);
        P1text3.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P1text3.SetActive(false);
        dialoagBackground1.SetActive(false);
        dialoagBackground2.SetActive(true);
        P2text1.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P2text1.SetActive(false);
        P2text2.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P2text2.SetActive(false);
        dialoagBackground2.SetActive(false);
        dialoagBackground1.SetActive(true);
        P1text4.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P1text4.SetActive(false);
        P1text5.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P1text5.SetActive(false);
        dialoagBackground1.SetActive(false);
        dialoagBackground2.SetActive(true);
        P2text3.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P2text3.SetActive(false);
        P2text4.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        P2text4.SetActive(false);
        dialoagBackground2.SetActive(false);
        dialoagBackground1.SetActive(true);
        P1text6.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        //
        dialoagBackground1.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void FriendCome(){
        anotherAnt.SetActive(true);
        anotherAntWall.SetActive(true);
    }
}
