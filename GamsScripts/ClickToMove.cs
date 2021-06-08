using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class ClickToMove : MonoBehaviour
{
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool IsWalk = false;
    public GameObject gameoverDialog;
    public AudioSource dieSFX;


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;

        if(!EventSystem.current.IsPointerOverGameObject()){
           MovePlayer(ray);
        }
    }
    void MovePlayer(Ray ray){
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(ray, out hit, 100)){
                mNavMeshAgent.destination = hit.point;
            }
        }

        if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance){
            IsWalk = false;
        }else{
            IsWalk = true;
        }
        mAnimator.SetBool("IsWalk",IsWalk);
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Enemy"){
            GameOver();
        }
    }
    void GameOver(){
        dieSFX.Play();
        gameoverDialog.SetActive(true);
    }   
}
