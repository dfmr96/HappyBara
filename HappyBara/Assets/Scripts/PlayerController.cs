using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider interactCollider;
    Vector3 forward;
    public int food = 100;
    [SerializeField]float interactTimer;
    float interactCooldown = 1f;

    private void Start()
    {
        forward = Vector3.forward;
        interactTimer = interactCooldown;
    }

    private void Update()
    {
        PlayerTurn();
        PlayerMovement();
    }

    void PlayerTurn ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0, -4, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.angularVelocity = new Vector3(0, 4, 0);

        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    void PlayerMovement ()
    {
        if (Input.GetKey(KeyCode.W))
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
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void UseFood(int foodUsed)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        food -= foodUsed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        interactTimer -= Time.deltaTime;

        if(other.gameObject.CompareTag("Animal") && Input.GetKey(KeyCode.E) && interactTimer < 0)
        {
            other.gameObject.GetComponent<CarpinchoStats>().IncreaseFood();
            food -= other.gameObject.GetComponent<CarpinchoStats>().foodPerUse;
            Debug.Log(other.gameObject.name + "fue alimentado");
            interactTimer = interactCooldown;
        }

        if (other.gameObject.CompareTag("Truck") && Input.GetKey(KeyCode.E) && interactTimer < 0)
        {
            other.gameObject.GetComponent<TruckScript>().LoadCarpincho();
        }
    }
}
