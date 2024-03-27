using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCañon : MonoBehaviour
{
    public GameObject cañon;       
    public GameObject centro;
    public ManagementCañon SpawnCañon()
    {
        ManagementCañon newCannon = Instantiate(cañon).GetComponent<ManagementCañon>();
        newCannon.GetComponent<ManagementCañon>().SetPositionCañon(centro.transform);
        return newCannon;
    }
    
}
