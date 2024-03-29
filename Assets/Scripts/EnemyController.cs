using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    private GameObject _player;

    

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        agent.SetDestination(_player.transform.position);
    }

    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
