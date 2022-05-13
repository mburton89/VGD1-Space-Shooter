using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartSoundManager : MonoBehaviour
{
    public static SmartSoundManager Instance;
    [SerializeField] List<AudioSource> laserSounds;
    int laserSoundIndex;

    [SerializeField] List<AudioSource> shipHitSounds;
    int shipHitSoundIndex;


    [SerializeField] AudioSource healthRegenSound;
    [SerializeField] AudioSource music1;
    [SerializeField] AudioSource music2;

    [SerializeField] AudioSource thrustSound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayLaserSound()
    {
        if (laserSoundIndex >= laserSounds.Count)
        {
            laserSoundIndex = 0;
        }
        laserSounds[laserSoundIndex].Play();
        laserSoundIndex++;
    }

    public void PlayShipHitSound()
    {
        if (shipHitSoundIndex >= shipHitSounds.Count)
        {
            shipHitSoundIndex = 0;
        }
        shipHitSounds[shipHitSoundIndex].Play();
        shipHitSoundIndex++;
    }

    public void PlayHealthRegenSound()
    {
        healthRegenSound.Play();
    }

    public void ToggleThrustSound(bool playSound)
    {
        if (playSound)
        {
            thrustSound.volume = .6f;
        }
        else
        {
            thrustSound.volume = 0;
        }
    }

    public void ToggleMusic()
    {
        //if (music1.isPlaying)
        //{
        //    music1.Stop();
        //    music2.Play();
        //}
        //else
        //{
        //    music2.Stop();
        //    music1.Play();
        //}
    }
}
