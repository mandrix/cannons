using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCreator : MonoBehaviour
{
    public GameObject cannonPrefab;       
    public GameObject centro;
    public CannonManagement SpawnCannon()
    {
        CannonManagement newCannon = Instantiate(cannonPrefab).GetComponent<CannonManagement>();
        newCannon.GetComponent<CannonManagement>().SetPositionCannon(centro.transform);
        return newCannon;
    }
    
}
