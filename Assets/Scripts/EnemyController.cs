using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    private GameObject _player;
    [SerializeField] public bool isOnLink;

    void Update()
    {
        isOnLink = _agent.isOnOffMeshLink;
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _agent.SetDestination(_player.transform.position);

    }

    public void SetTarget(Transform target)
    {
        _agent.SetDestination(target.position);
    }
}
