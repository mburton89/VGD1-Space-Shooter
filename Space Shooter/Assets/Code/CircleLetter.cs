using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircleLetter: MonoBehaviour
{
    public TextMeshProUGUI letter;
    public float rotationSpeed;
    public float secondsToLive;

    AudioSource blipSound;

    void Start()
    {
        blipSound = GetComponent<AudioSource>();
        blipSound.pitch = Random.Range(.9f, 1.2f);
        blipSound.Play();
        Destroy(gameObject, secondsToLive);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);

        //print(transform.rotation.eulerAngles.z);
    }
}
