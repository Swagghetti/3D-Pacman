using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] Transform _firstEnd;
    [SerializeField] Transform _secondEnd;
    [SerializeField] bool _isUsed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNodeTrigger(GameObject ball)
    {
        if (ball.GetComponent<EnemyController>().isOnLink)
        {
            GetDestination(ball);
        }
    }

    private void GetDestination(GameObject ball)
    {
        if (Vector3.Distance(ball.transform.position, _firstEnd.position) < 0.8f)
        {
            Debug.Log("Second end: " + _secondEnd.transform.position.x + " " + _secondEnd.transform.position.z);
            TeleportToLocation(ball, _secondEnd);
        }
        else if (Vector3.Distance(ball.transform.position, _secondEnd.position) < 0.8f)
        {
            Debug.Log("First end: " + _firstEnd.transform.position.x + " " + _firstEnd.transform.position.z);
            TeleportToLocation(ball, _firstEnd);
        }

        
    }

    private void TeleportToLocation(GameObject enemy, Transform destination)
    {
        Debug.Log("TeleportToLocation " + destination.position.x + ", " + destination.position.x);
        enemy.GetComponent<EnemyController>().agent.Warp(destination.position);
        enemy.GetComponent<EnemyController>().SetTargetAsPlayer();
    }
}
