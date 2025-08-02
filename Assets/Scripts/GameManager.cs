using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CannonCreator spawnCannon;
    public List<CannonManagement> cannons;
    public List<PirateManager> pirates;
    public AudioManager AudioManager;
    public Transform centerCannon;
    public PirateSpawnManager spawnPirate;
    public Matriz matriz;
    public Cuadricula cuadricula;
    public int round = 0;
    void Start()
    {
        matriz = GetComponent<Matriz>();
        matriz.SetDimensions(4, 5);
        spawnCannon = GetComponent<CannonCreator>();
        spawnPirate = GetComponent<PirateSpawnManager>();
        spawnPirate.SetMatriz(matriz);
        nextRound();
        GameFlow1();
        AudioManager.PlayNormalLvl();
    }

    public void nextRound()
    {
      
        PirateAdvance();
        if (cuadricula.filas.Count > round)
        {
            SpawnPiratesForRound(cuadricula.filas[round]);
        }
        round++;
    }

    public void SpawnPiratesForRound(Fila fila)
    {
        foreach (Fila.Cuadro cuadro in fila.cuadros)
        {
            if(cuadro.tipo >= 1)
            {
                NextPirate(cuadro);
            }
        }
    }
    public void NextPirate(Fila.Cuadro cuadro)
    {
        PirateManager newPirate = spawnPirate.SpawnPirate(cuadro);
        newPirate.SetManager(this);
        pirates.Add(newPirate);
    }
    public void RemovePirate(PirateManager pirate)
    {
        pirates.Remove(pirate);
    }
    public void PirateAdvance()
    {
        foreach (PirateManager pirate in pirates)
        {
            pirate.Advance();
        }
    }
    public CannonCreator SpawnCannon() => spawnCannon;

    public void GameFlow2()
    {
        foreach (CannonManagement cannon in cannons)
        {
            cannon.SetCannon();
        }
        foreach (CannonManagement cannon in cannons)
        {
            cannon.Shoot();
        }

        //validad el gane 
        // poner a los enemigos a moverse
        //validad  perdida 

        foreach (CannonManagement cannon in cannons) // volver a mover los cannones
        {
            cannon.UnsetCannon();
        }                                                       
        Invoke(nameof(GameFlow1), 5f);  // reiniciar el ciclo
        Invoke(nameof(nextRound), 5f);  // reiniciar el ciclo
    }                                                               

    void GameFlow1()
    {
        //NextPirate();
        CannonManagement newCannon = spawnCannon.SpawnCannon();
        newCannon.SetManager(this);
        newCannon.SetCenter(centerCannon);
        newCannon.CenterCannon();
        foreach (CannonManagement cannon in cannons)
        {
            cannon.UnsetCannon();
        }
        cannons.Add(newCannon);

    }
}
