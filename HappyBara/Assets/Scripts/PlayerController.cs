using TMPro;
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
    public GameObject feed_QTE;
    public GameObject canvas;
    bool isOnQTE = false;

    [SerializeField] TMP_Text foodText;

    private void Start()
    {
        forward = Vector3.forward;
        interactTimer = interactCooldown;
        foodText.text = food.ToString();
    }

    private void Update()
    {
        if (!isOnQTE)
        {
            PlayerTurn();
            PlayerMovement();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.sharedInstance.TooglePause();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
        } else
        {
            speed = 6;
        }
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
        food -= foodUsed;
        foodText.text = food.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        interactTimer -= Time.deltaTime;

        if (other.gameObject.CompareTag("Animal") && Input.GetKey(KeyCode.E) && interactTimer < 0)
        {
            if (!isOnQTE)
            {
                isOnQTE = true;
                feed_QTE.SetActive(true);

                interactTimer = interactCooldown;
            }
            else
            {
                if (feed_QTE.GetComponent<Slider_QTE>().SuccessAction())
                {
                    other.gameObject.GetComponent<CarpinchoStats>().IncreaseFood();
                    UseFood(other.gameObject.GetComponent<CarpinchoStats>().foodPerUse);
                    Debug.Log(other.gameObject.name + " fue alimentado con exito");
                    interactTimer = interactCooldown;

                    if (other.gameObject.GetComponent<CarpinchoStats>().CatchCarpincho())
                    {
                        feed_QTE.GetComponent<Slider_QTE>().TurnOffText();
                        feed_QTE.SetActive(false);
                        isOnQTE = false;
                    }
                    else
                    {
                        feed_QTE.GetComponent<Slider_QTE>().ReInitQTE();
                    }
                }
                else
                {
                    feed_QTE.GetComponent<Slider_QTE>().ReInitQTE();
                    UseFood(other.gameObject.GetComponent<CarpinchoStats>().foodPerUse);
                    Debug.Log(other.gameObject.name + " no pudo ser alimentado");
                    isOnQTE = false;
                }
            }
        }

        if (other.gameObject.CompareTag("Truck") && Input.GetKey(KeyCode.E) && interactTimer < 0)
        {
            other.gameObject.GetComponent<TruckScript>().LoadCarpincho();
        }
    }
}
