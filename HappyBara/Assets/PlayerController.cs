using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Vector3 forward;
    private void Start()
    {
        forward = Vector3.forward;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0,-4,0);
        }

        else if (Input.GetKey(KeyCode.D)){
            rb.angularVelocity = new Vector3(0, 4, 0);

        }

        else if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = rb.transform.forward * 6;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = rb.transform.forward * -6;
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(rb.transform.up * 400);
        } else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
