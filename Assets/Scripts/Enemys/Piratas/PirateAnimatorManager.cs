using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAnimatorManager : MonoBehaviour
{
    public Animator pirateAnimator;
    void Start()
    {
    }

    public void PlayAttack() => PlayAnimation("Atacar");
    public void PlayFall() => PlayAnimation("Caerse");

    public void PlayGetHit() => PlayAnimation("Recibir golpe");
    public void PlayAdvance() => PlayAnimation("avanzar 2");   // falta que sea auto asigne alguno de los difeentes maneras de avanzar 
    public void PlayIdle() => PlayAnimation("esperando");    // falta que sea un loop entre los diferentes idles 


    public void DyingProcess() {
        PlayAnimation("Caerse");
    }
    public Animator PirateAnimator => pirateAnimator;
    void PlayAnimation(string nameAnimation)
    {
        if (nameAnimation != null && !string.IsNullOrEmpty(nameAnimation))
        {
            pirateAnimator.Play(nameAnimation);
        }
        else
        {
            Debug.LogWarning("Animator o nombre de animación no válidos.");
        }
    }

}
