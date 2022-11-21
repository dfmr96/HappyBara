using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    [SerializeField] GameObject mainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;

        if (sharedInstance == null)
        {
            sharedInstance = this;
        } else
        {
            Destroy(sharedInstance);
        }
    }

    public GameObject GetCamera()
    {
        return mainCamera;
    }

}
