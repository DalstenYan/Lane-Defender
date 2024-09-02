using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource sfxSource;

    [SerializeField]
    AudioClip bgmMusic;
    [SerializeField]
    AudioClip hitSound;
    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    AudioClip shoot;
    [SerializeField]
    AudioClip lostlife;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = bgmMusic;
        musicSource.Play();

    }

    public void HitSound(bool isDead)
    {
        if (isDead)
            sfxSource.PlayOneShot(deathSound);
        else
            sfxSource.PlayOneShot(hitSound);
    }

    public void ShootSound() 
    {
        sfxSource.PlayOneShot(shoot);
    }

    public void LostLife() 
    {
        sfxSource.PlayOneShot(lostlife);
    }

}
