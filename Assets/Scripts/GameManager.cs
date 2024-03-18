using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CrearCañon spawnCannon;
    public List<ManagementCañon> cannons;
    public AudioManager AudioManager;
    public GameObject[,] enemysMatriz;
    void Start()
    {
        enemysMatriz = new GameObject[5, 3];
        spawnCannon = GetComponent<CrearCañon>();
        GameFlow1();
        AudioManager.PlayNormalLvl();
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

        //validad el gane 
        // poner a los enemigos a moverse
        //validad  perdida 

        foreach (ManagementCañon cannon in cannons)       // volver a mover los cañones
        {
            cannon.UnsetCannon();
        }                                                           
        Invoke(nameof(GameFlow1), 5f);  // reiniciar el ciclo
    }                                                               

    void GameFlow1()
    {
        ManagementCañon newCannon = spawnCannon.SpawnCañon();
        newCannon.SetManager(this);
        foreach (ManagementCañon cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        cannons.Add(newCannon);

    }
}
