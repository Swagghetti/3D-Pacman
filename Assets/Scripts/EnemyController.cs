using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    private GameObject _player;
    [SerializeField] public bool isOnLink;

    void Update()
    {
        isOnLink = agent.isOnOffMeshLink;
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        agent.SetDestination(_player.transform.position);

    }

    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    public void SetTargetAsPlayer()
    {
        agent.SetDestination(_player.transform.position);
    }
}
