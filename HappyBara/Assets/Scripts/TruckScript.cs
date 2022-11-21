using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    [SerializeField] GameObject playerWOAnimal;
    [SerializeField] GameObject playerWithAnimal;
    [SerializeField] List<GameObject> carpinchosOnTruck = new List<GameObject>();
    public void LoadCarpincho()
    {
        if (playerWithAnimal.activeInHierarchy)
        {
            for(int i = 0; i < carpinchosOnTruck.Count ; i++)
            {
                if (!carpinchosOnTruck[i].activeInHierarchy)
                {
                    carpinchosOnTruck[i].SetActive(true);
                    playerWOAnimal.SetActive(true);
                    playerWithAnimal.SetActive(false);
                    return;
                }
            }
        }
    }
}
