using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField]
    [Tooltip("El daño de la bala.")]
    [Range(1, 10)]
    private int damage = 1; // Atributo privado

    // Getter para obtener el valor de Damage
    public int Damage => damage;

    // Setter para establecer el valor de Damage
    public void SetDamage(int newDamage) => damage = newDamage;
}
