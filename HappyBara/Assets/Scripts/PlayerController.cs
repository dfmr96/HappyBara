using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider interactCollider;
    Vector3 forward;
    public int food = 100;
    public int angularSpeed;
    public int speed;
    [SerializeField] float interactTimer;
    float interactCooldown = 1f;
    public GameObject feed_QTE_Prefab;
    public GameObject feed_QTE;
    public GameObject canvas;
    bool isOnQTE = false;

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

    void PlayerTurn()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0, -angularSpeed, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.angularVelocity = new Vector3(0, angularSpeed, 0);

        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = rb.transform.forward * speed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = rb.transform.forward * -speed;
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

        if (other.gameObject.CompareTag("Animal") && Input.GetKey(KeyCode.E) && interactTimer < 0)
        {
            if (!isOnQTE)
            {
                feed_QTE = Instantiate(feed_QTE_Prefab);
                feed_QTE.transform.SetParent(canvas.transform);
                feed_QTE.GetComponent<Slider_QTE>().MoveUI();
                interactTimer = interactCooldown;
                isOnQTE = true;
            }
            else
            {
                if (feed_QTE.GetComponent<Slider_QTE>().SuccessAction())
                {
                    other.gameObject.GetComponent<CarpinchoStats>().IncreaseFood();
                    food -= other.gameObject.GetComponent<CarpinchoStats>().foodPerUse;
                    Debug.Log(other.gameObject.name + " fue alimentado con exito");
                    interactTimer = interactCooldown;
                    
                    if (other.gameObject.GetComponent<CarpinchoStats>().CatchCarpincho())
                    {
                        Destroy(feed_QTE);
                    } else
                    {
                        feed_QTE.GetComponent<Slider_QTE>().ReInitQTE();
                    }
                }
                else
                {
                    food -= other.gameObject.GetComponent<CarpinchoStats>().foodPerUse;
                    Debug.Log(other.gameObject.name + " no pudo ser alimentado");
                    Destroy(feed_QTE);
                    isOnQTE = false;
                }
            }
        }

        if (other.gameObject.CompareTag("Animal") && Input.GetKey(KeyCode.E) && interactTimer < 0 && isOnQTE == true)
        {

        }

        if (other.gameObject.CompareTag("Truck") && Input.GetKey(KeyCode.E) && interactTimer < 0)
        {
            other.gameObject.GetComponent<TruckScript>().LoadCarpincho();
        }
    }
}
