using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateManager : MonoBehaviour
{
    private PirateAnimatorManager animatorManager;
    [SerializeField]
    [Tooltip("La vida inicial del Enemigo.")]
    [Range(0, 100)]
    private int hp = 5;

    public Transform pivot;
    void Start()
    {
        animatorManager = gameObject.GetComponent<PirateAnimatorManager>();
        animatorManager.PlayIdle();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        animatorManager.PlayGetHit();
        if (hp <= 0)
        {
            GetComponentInChildren<PirateTakesDamage>().Delete();
            Invoke(nameof(Delete), 5f);
            animatorManager.PlayFall();
        }
    }

    public void D() {
        Vector3 newPosition = transform.position;
        newPosition.x = pivot.localPosition.x;
        transform.position = newPosition;
    }
    IEnumerator RelocatePirate()
    {
        animatorManager.PlayAdvance();
        float f = animatorManager.PirateAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(1.04f);              // hacer algo para que las 2 animaciones tengan su tiempo aqui

        Vector3 newPosition = transform.position;
        newPosition.x = pivot.localPosition.x;
        transform.position = newPosition;
    }
    public void Delete() => Destroy(gameObject);

}
