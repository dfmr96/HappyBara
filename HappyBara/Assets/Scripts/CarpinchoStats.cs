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

        if (CatchCarpincho())
        {
            playerWOAnimal.SetActive(false);
            playerWithAnimal.SetActive(true);
            Destroy(gameObject);
        }
    }

    public bool CatchCarpincho()
    {
        if (food >= foodNeed)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
