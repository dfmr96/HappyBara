using UnityEngine;

public class CarpinchoController : MonoBehaviour
{

    public float speed = 6f;
    public float angularSpeed = 6f;
    public Vector3 speedVector = new Vector3(1, 0, 1);
    Rigidbody animalRigidbody;

    public bool isWalking;

    public float walkTime = 1.5f;
    [SerializeField] float walkCounter;

    public float waitTime = 3.0f;
    [SerializeField] float waitCounter;
    bool beingFeed = false;

    Vector3[] walkingDirection =
    {
        new Vector3(1,0,0),
        new Vector3(0,0,1),
        new Vector3(-1,0,0),
        new Vector3(0,0,-1),
    };

    Vector3 directionToMove;

    int currentDirection;

    public BoxCollider walkingZone;

    private void Start()
    {
        animalRigidbody = GetComponent<Rigidbody>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        //currentDirection = Random.Range(0, 4);
    }

    private void Update()
    {
        if (isWalking && !beingFeed)
        {
            /*if (walkingZone != null)
            {

                if (this.transform.position.x < walkingZone.bounds.min.x || this.transform.position.x > walkingZone.bounds.max.x || this.transform.position.z < walkingZone.bounds.min.z || this.transform.position.z > walkingZone.bounds.max.z)
                {
                    directionToMove = (new Vector3(Random.Range(walkingZone.bounds.min.x, walkingZone.bounds.max.x), this.transform.position.y, Random.Range(walkingZone.bounds.min.z, walkingZone.bounds.max.z)) - this.transform.position).normalized * speed;
                    animalRigidbody.velocity = directionToMove;
                }
            }*/

            //if (animalRigidbody.velocity.magnitude <= 0.5)
            //{
            transform.position += walkingDirection[currentDirection] * Time.deltaTime * speed;
            if (walkingDirection[currentDirection].z > 0)
            {
            transform.rotation = Quaternion.Euler(new Vector3(0,walkingDirection[currentDirection].x * 90 + walkingDirection[currentDirection].z * 0, 0));
            } else
            {
            transform.rotation = Quaternion.Euler(new Vector3(0, walkingDirection[currentDirection].x * 90 + walkingDirection[currentDirection].z * -180, 0));

            }
            // }
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            //animalRigidbody.velocity = Vector3.zero;
            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
            {
                StartWalking();
            }
        }

        //animalRigidbody.MovePosition(walkingDirection[currentDirection] * Time.deltaTime * speed);
        //animalRigidbody.MoveRotation(Quaternion.Euler(walkingDirection[currentDirection]));
    }

    public void StopForFeed()
    {
        beingFeed = true;
    }

    void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }

    void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        animalRigidbody.velocity = Vector3.zero;
    }
}
