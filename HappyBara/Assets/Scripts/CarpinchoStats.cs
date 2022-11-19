using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpinchoStats : MonoBehaviour
{
    [SerializeField]int foodNeed = 3;
    public int foodPerUse = 1;
    [SerializeField]int food = 0;

    public void IncreaseFood()
    {
        food += foodPerUse;

        if (food >= foodNeed)
        {
            Destroy(gameObject);
        }
    }
}
