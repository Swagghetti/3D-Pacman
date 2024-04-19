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
        GetDestination(ball);
    }

    private void GetDestination(GameObject ball)
    {
        Debug.Log("Distance " + Vector3.Distance(ball.transform.position, _firstEnd.position));
        Debug.Log("Distance " + Vector3.Distance(ball.transform.position, _secondEnd.position));

        if (Vector3.Distance(ball.transform.position, _firstEnd.position) < 3f)
        {
            TeleportToLocation(ball, _secondEnd);
        }
        else if (Vector3.Distance(ball.transform.position, _secondEnd.position) < 3f)
        {
            TeleportToLocation(ball, _firstEnd);
        }
    }

    private void TeleportToLocation(GameObject enemy, Transform destination)
    {
        Debug.Log("TeleportToLocation " + destination.position.x + ", " + destination.position.x);
        enemy.transform.position = destination.position;
    }
}
