using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdPathingScript : MonoBehaviour
{
    private Animator npcAnimator;
    private NavMeshAgent npcNavMeshAgent;
    private bool IsWalk = false,IsFly = false,switchEvent = false;
    public GameObject destination1,destination2;
    public float waitTime,baseOffsetVal;
    public GameObject eventStarter;
    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        npcNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void CheckEvent(){
        if(eventStarter.activeSelf == true){
            npcNavMeshAgent.SetDestination(destination1.transform.position);
            StartCoroutine(WaitFor());
            eventStarter.SetActive(false);
        }
    }
    IEnumerator WaitFor(){
        yield return new WaitForSeconds(waitTime);
        switchEvent = true;
        npcNavMeshAgent.SetDestination(destination2.transform.position);
        destination1.SetActive(false);
    }
    void WalkAnimation(){
        if(npcNavMeshAgent.remainingDistance <= npcNavMeshAgent.stoppingDistance){
                IsWalk = false;
                IsFly = false;
            }else{
                IsWalk = true;
                IsFly = false;
            }
            npcAnimator.SetBool("IsWalk",IsWalk);
            npcAnimator.SetBool("IsFly",IsFly);
    }
    void FlyAnimation(){
        if(npcNavMeshAgent.remainingDistance <= npcNavMeshAgent.stoppingDistance){
            IsWalk = false;
            IsFly = false;
        }else{
            IsWalk = false;
            IsFly = true;
        }
        npcAnimator.SetBool("IsWalk",IsWalk);
        npcAnimator.SetBool("IsFly",IsFly);
        if(npcNavMeshAgent.baseOffset < baseOffsetVal){
            npcNavMeshAgent.baseOffset = npcNavMeshAgent.baseOffset+0.05f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckEvent();
        if(switchEvent == false){
            WalkAnimation();
        }else
        {
            FlyAnimation();
        }
    }
}
