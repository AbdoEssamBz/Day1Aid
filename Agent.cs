using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public Transform Player;

    public Transform[] pointsavisiter;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        VaAuProchainPoint();
    }

    void VaAuProchainPoint()
    {
        if (pointsavisiter.Length == 0)
            return;
        agent.destination = pointsavisiter[destPoint].position;
        destPoint = (destPoint + 1) % pointsavisiter.Length;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            VaAuProchainPoint();


        void OverLapShpere(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    Vector3 targetPosition = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
                transform.LookAt(targetPosition);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Touch");
           Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
            gameObject.transform.localScale += scaleChange;
        }
      
    }
}








/*
[SerializeField]
private Transform Plane;
private NavMeshAgent NavMeshAgentagent;
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    NavMeshAgentagent= GetComponent<NavMeshAgent>();
}

// Update is called once per frame
void Update()
{
    NavMeshAgentagent.SetDestination(Plane.transform.position);
}
}

*/
