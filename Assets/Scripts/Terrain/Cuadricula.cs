using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Cuadricula", menuName = "Cuadricula/Cuadricula", order = 3)]
public class Cuadricula: ScriptableObject
{
    public List<Fila> filas;
}