using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _rb.AddTorque(transform.up * _rotateSpeed * Input.GetAxis("Horizontal"), ForceMode.VelocityChange);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            _rb.AddForce(transform.forward * _speed * Input.GetAxis("Vertical"));
        }
    }
}