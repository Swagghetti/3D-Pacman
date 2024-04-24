using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] NavMeshLink _navMeshLink;
    [SerializeField] Transform _firstEnd;
    [SerializeField] Transform _secondEnd;
    [SerializeField] bool _isUsed;

    void Start()
    {
        _navMeshLink.startPoint = _secondEnd.position;
        _navMeshLink.endPoint = _firstEnd.position;
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

    public void GetDestination(GameObject ball)
    {
        float threshold = ball.transform.localScale.y / 2 + 0.5f;
        if (Vector3.Distance(ball.transform.position, _firstEnd.position) < threshold)
        {
            Debug.Log("Second end: " + _secondEnd.transform.position.x + " " + _secondEnd.transform.position.z);
            TeleportToLocation(ball, _secondEnd);
        }
        else if (Vector3.Distance(ball.transform.position, _secondEnd.position) < threshold)
        {
            Debug.Log("First end: " + _firstEnd.transform.position.x + " " + _firstEnd.transform.position.z);
            TeleportToLocation(ball, _firstEnd);
        }
        
    }

    private void TeleportToLocation(GameObject ball, Transform destination)
    {
        Debug.Log("TeleportToLocation " + destination.position.x + ", " + destination.position.x);

        if (ball.tag == "Player")
        {
            ball.GetComponent<PlayerController>().agent.Warp(destination.position);
        }
        else if (ball.tag == "Enemy")
        {
            ball.GetComponent<EnemyController>().agent.Warp(destination.position);
            ball.GetComponent<EnemyController>().SetTargetAsPlayer();
        }
        
    }
}
