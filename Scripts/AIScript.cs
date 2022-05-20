using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AIScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;
    public ThirdPersonCharacter character;
    private void Start()
    {
        navMeshAgent.SetDestination(target.position);
    }
    private void Update()
    {
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            character.Move(navMeshAgent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

}