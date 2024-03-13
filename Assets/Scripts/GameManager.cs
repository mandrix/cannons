using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CrearCañon spawnCannon;
    public List<ManagementCañon> cannons;
    void Start()
    {
        spawnCannon = GetComponent<CrearCañon>();
        GameFlow1();
    }

    
    void Update()
    {
        
    }

    public void GameFlow2()
    {
        Debug.Log("no se puede");
        foreach (ManagementCañon cannon in cannons)
        {
            cannon.SetCannon();
        }
        foreach (ManagementCañon cannon in cannons)
        {
            cannon.Shoot();
        }
        // poner  a los cañones a atacar 
        //validad el gane 
        // poner a los enemigos a moverse
        //validad  perdida 

        foreach (ManagementCañon cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        //GameFlow1();
    }

    void GameFlow1()
    {
        Debug.Log("se puede");
        ManagementCañon newCannon = spawnCannon.SpawnCañon();
        newCannon.SetManager(this);
        foreach (ManagementCañon cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        cannons.Add(newCannon);

    }
}
