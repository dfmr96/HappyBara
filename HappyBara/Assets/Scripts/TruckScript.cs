using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    [SerializeField] GameObject playerWOAnimal;
    [SerializeField] GameObject playerWithAnimal;
    [SerializeField] GameObject carpincho_1;
    public void LoadCarpincho()
    {
        if (playerWithAnimal.activeInHierarchy == true)
        {
            playerWOAnimal.SetActive(true);
            playerWithAnimal.SetActive(false);
            carpincho_1.SetActive(true);
        }
    }
}
