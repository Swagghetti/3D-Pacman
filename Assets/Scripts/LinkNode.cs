using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkNode : MonoBehaviour
{
    [SerializeField] Link link;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            link.OnNodeTrigger(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}
