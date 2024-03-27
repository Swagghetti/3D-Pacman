using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    private GameObject _player;

    private float _refreshDuration = 3.3f;
    private float _refreshTimer = 0.0f;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        agent.SetDestination(_player.transform.position);
    }


    private void FixedUpdate()
    {
        _refreshTimer += Time.deltaTime;
        if (_refreshTimer > _refreshDuration)
        {
            Debug.Log("refreshing path");
            agent.SetDestination(_player.transform.position);
            _refreshTimer = 0.0f;
        }
    }
}
