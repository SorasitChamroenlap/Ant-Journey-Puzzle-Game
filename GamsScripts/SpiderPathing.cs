using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderPathing : MonoBehaviour
{
    private Animator npcAnimator;
    private NavMeshAgent npcNavMeshAgent;
    public Transform targetDestination1,targetDestination2;
    private bool IsWalk = false;
    public bool isSinglePath;
    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        npcNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void OnTriggerEnter(Collider other){
       HitTarget(other);
    } 
    void HitTarget(Collider other){
         if(isSinglePath == true){
            npcNavMeshAgent.SetDestination(targetDestination1.position);
        }else{
            if(other.tag == "pos1"){
                npcNavMeshAgent.SetDestination(targetDestination2.position);
            }
            if(other.tag == "pos2"){
                npcNavMeshAgent.SetDestination(targetDestination1.position);
            }
        }
    }
    void CheckAnimation(){
        if(npcNavMeshAgent.remainingDistance <= npcNavMeshAgent.stoppingDistance){
                IsWalk = false;
            }else{
                IsWalk = true;
            }
            npcAnimator.SetBool("isWalk",IsWalk);
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
    }
}
