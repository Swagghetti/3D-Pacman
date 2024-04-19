using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkNode : MonoBehaviour
{
    [SerializeField] Link link;
    [SerializeField] bool inCollider;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("OnTriggerStay " + inCollider + " " + other.tag);
            inCollider = true;
            link.OnNodeTrigger(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        inCollider = false;
    }
}