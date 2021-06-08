using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntGoOutPath : MonoBehaviour
{
    public GameObject agentDestination;
    private NavMeshAgent enemyAgent;
    private Animator enemyAnimator;
    private bool IsWalk = false;
    public bool startWalk = false;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "barrier"){
            Destroy(gameObject);
        }
    }
    public void BeginStartWalk(){
        startWalk = true;
    }
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startWalk == true){
            enemyAgent.SetDestination(agentDestination.transform.position);
            if(enemyAgent.remainingDistance <= enemyAgent.stoppingDistance){
                    IsWalk = false;
                }else{
                    IsWalk = true;
                }
            enemyAnimator.SetBool("IsWalk",IsWalk);
        }  
    }
}
