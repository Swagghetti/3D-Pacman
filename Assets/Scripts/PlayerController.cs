using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public NavMeshAgent agent;
    public bool isOnLink;
    [SerializeField] private GameObject _link;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnLink)
        {
            _link.GetComponent<Link>().GetDestination(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Link"))
        {
            isOnLink = true;
            _link = other.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Link"))
        {
            isOnLink = false;
            _link = null;
        }
    }
}
