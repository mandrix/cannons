using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CrearCa�on spawnCannon;
    public List<ManagementCa�on> cannons;
    void Start()
    {
        spawnCannon = GetComponent<CrearCa�on>();
        GameFlow1();
    }

    
    void Update()
    {
        
    }

    public void GameFlow2()
    {
        Debug.Log("no se puede");
        foreach (ManagementCa�on cannon in cannons)
        {
            cannon.SetCannon();
        }
        foreach (ManagementCa�on cannon in cannons)
        {
            cannon.Shoot();
        }
        // poner  a los ca�ones a atacar 
        //validad el gane 
        // poner a los enemigos a moverse
        //validad  perdida 

        foreach (ManagementCa�on cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        //GameFlow1();
    }

    void GameFlow1()
    {
        Debug.Log("se puede");
        ManagementCa�on newCannon = spawnCannon.SpawnCa�on();
        newCannon.SetManager(this);
        foreach (ManagementCa�on cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        cannons.Add(newCannon);

    }
}
