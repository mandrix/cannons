using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Fila", menuName = "Fila/Fila", order = 3)]
public class Fila : ScriptableObject
{
    [Serializable]
    public class Cuadro
    {

        [Tooltip("indice comienza de derecha a izquierda (0-5)")]
        [SerializeField] // Para que sea visible en el Inspector
        private int index;

        public int Index => index;

        [Tooltip("tipo dicta el tipo de pirata, por ahora siempre sera 1 si hay, 0 si no hay")]
        [Range(0, 1)]
        public int tipo = 0;

        [Tooltip("cuanto daño recibira antes de morir")]
        [Range(1, 5)]
        public int hp = 1;

        public Cuadro(int newIndex, int newTipo, int newHp)
        {
            index = newIndex;
            tipo = newTipo;
            hp = newHp;
        }
    }

    public List<Cuadro> cuadros;


    [ContextMenu("Inicializar con 5 Cuadros")]
    public void InicializarCon5Cuadros()
    {
        cuadros.Clear();

        for (int i = 0; i < 5; i++)
        {
            cuadros.Add(new Cuadro(i, 0, 1));
        }
    }

}