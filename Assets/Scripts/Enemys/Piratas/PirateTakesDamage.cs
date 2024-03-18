using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateTakesDamage : MonoBehaviour
{

    private PirateManager pirate;

    private void Start()
    {
        pirate = GetComponentInParent<PirateManager>();
    }
    public void Delete() => Destroy(gameObject);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shoot"))
        {
            int damage = other.GetComponent<BulletDamage>().Damage;

            pirate.TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }
}
