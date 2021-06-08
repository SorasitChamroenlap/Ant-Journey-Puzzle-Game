using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeePathingScript : MonoBehaviour
{
    private Animator npcAnimator;
    private NavMeshAgent npcNavMeshAgent;
    public Transform targetDestination;
    public float baseOffsetVal;
    public GameObject eventStatrer;
    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        npcNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void CheckMove(){
        if(eventStatrer == null){
            npcNavMeshAgent.SetDestination(targetDestination.position);
        }
    }
    void PlayAnimation(){
        npcNavMeshAgent.baseOffset = baseOffsetVal;
        npcAnimator.SetBool("IsFly",true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnimation();
        CheckMove();
    }
}
