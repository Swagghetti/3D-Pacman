using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private Rigidbody _rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb.velocity = new Vector3(-_speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = new Vector3(_speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = new Vector3(0, 0, _speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rb.velocity = new Vector3(0, 0, -_speed);
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
