using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float minRandomPitch;
    [SerializeField] float maxRandomPitch;

    [SerializeField] List<AudioSource> deflectSounds;
    int deflectSoundIndex;

    public enum SoundEffect
    {
        Deflect,
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundEffect soundEffect)
    {
        AudioSource audioSourceToPlay;
        float randPitch = Random.Range(minRandomPitch, maxRandomPitch);

        if (soundEffect == SoundEffect.Deflect)
        {
            audioSourceToPlay = deflectSounds[deflectSoundIndex];
            if (deflectSoundIndex < deflectSounds.Count - 1)
            {
                deflectSoundIndex++;
            }
            else
            {
                deflectSoundIndex = 0;
            }
        }
        else
        {
            audioSourceToPlay = null;
            Debug.LogWarning("Needs Audio Source!");
        }

        audioSourceToPlay.pitch = randPitch;
        audioSourceToPlay.Play();
    }
}
