using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCañon : MonoBehaviour
{
    public GameObject cañon;
    public GameObject centro;
    // Start is called before the first frame update
    void Start()
    {
    }
    public ManagementCañon SpawnCañon()
    {
        ManagementCañon newCannon = Instantiate(cañon).GetComponent<ManagementCañon>();
        newCannon.GetComponent<ManagementCañon>().SetPositionCañon(centro.transform);
        return newCannon;
    }
}
