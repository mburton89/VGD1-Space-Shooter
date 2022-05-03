<<<<<<< Updated upstream
using UnityEngine.Audio;    
=======
using UnityEngine.Audio;
>>>>>>> Stashed changes
using UnityEngine;

public class AudioManager : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
    public Sound[] sounds; 
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

   public void  Play (string name)
    {
        Sound s = Array.Find(sounds, Sound => sound.name == name);
        s.source.Play();
>>>>>>> Stashed changes
    }
}
