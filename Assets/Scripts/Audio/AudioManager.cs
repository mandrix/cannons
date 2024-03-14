using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip menu;
    public AudioClip normalLvl;
    public AudioClip hardLvl;
    public AudioClip endLvl;
    public AudioClip winLvl;
    public AudioClip loseLvl;
    public AudioClip bossLvl;


    private void Start()
    {
    }


    public void PlayMenu() => PlayClip(menu);
    public void PlayNormalLvl() => PlayClip(normalLvl);
    public void PlayHardLvl() => PlayClip(hardLvl);
    public void PlayEndLvl() => PlayClip(endLvl);
    public void PlayWinLvl() => PlayClip(winLvl);
    public void PlayLoseLvl() => PlayClip(loseLvl);
    public void PlayBossLvl() => PlayClip(bossLvl);


    void PlayClip(AudioClip clip)
    {
        audioSource.Pause();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
