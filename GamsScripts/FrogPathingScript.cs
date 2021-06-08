using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrogPathingScript : MonoBehaviour
{
    private Animator npcAnimator;
    private NavMeshAgent npcNavMeshAgent;
    private bool IsWalk = false;
    public GameObject destination1,destination2;
    public GameObject eventHolder,eventManager2;
    public float watingTime;
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
        if(other.tag == "pos1"){
            eventManager2.SetActive(true);
        }
        if(other.tag == "pos2"){
            eventManager2.SetActive(false);
        }
    }
    void StartEvent(){
        npcNavMeshAgent.SetDestination(destination1.transform.position);
        StartCoroutine(Wait());
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(watingTime);
        npcNavMeshAgent.SetDestination(destination2.transform.position);
    }void EnterEvent(){
        if(eventHolder.activeSelf == false){
            StartEvent();
        }
        eventHolder.SetActive(true);
    }
    void PlayAnimation(){
        if(npcNavMeshAgent.remainingDistance <= npcNavMeshAgent.stoppingDistance){
            IsWalk = false;
        }else{
            IsWalk = true;
        }
        npcAnimator.SetBool("IsWalk",IsWalk);
    }
    // Update is called once per frame
    void Update()
    {
        PlayAnimation();
        EnterEvent();
    }
}
