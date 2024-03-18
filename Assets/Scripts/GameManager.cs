using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CrearCa�on spawnCannon;
    public List<ManagementCa�on> cannons;
    public AudioManager AudioManager;
    public GameObject[,] enemysMatriz;
    void Start()
    {
        enemysMatriz = new GameObject[5, 3];
        spawnCannon = GetComponent<CrearCa�on>();
        GameFlow1();
        AudioManager.PlayNormalLvl();
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

        //validad el gane 
        // poner a los enemigos a moverse
        //validad  perdida 

        foreach (ManagementCa�on cannon in cannons)       // volver a mover los ca�ones
        {
            cannon.UnsetCannon();
        }                                                           
        Invoke(nameof(GameFlow1), 5f);  // reiniciar el ciclo
    }                                                               

    void GameFlow1()
    {
        ManagementCa�on newCannon = spawnCannon.SpawnCa�on();
        newCannon.SetManager(this);
        foreach (ManagementCa�on cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        cannons.Add(newCannon);

    }
}
