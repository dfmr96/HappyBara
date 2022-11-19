using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpinchoStats : MonoBehaviour
{
    [SerializeField] int foodNeed = 3;
    public int foodPerUse = 1;
    [SerializeField] int food = 0;
    [SerializeField] GameObject playerWOAnimal;
    [SerializeField] GameObject playerWithAnimal;
    public void IncreaseFood()
    {
        food += foodPerUse;

        if (food >= foodNeed)
        {
            playerWOAnimal.SetActive(false);
            playerWithAnimal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
