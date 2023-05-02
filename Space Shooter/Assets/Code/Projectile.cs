using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    public int damageToGive;
    [HideInInspector] public GameObject firingShip;
    public TextMeshProUGUI letter;
    public AudioSource blipSound;
    public AudioClip goodBlipSound;
    public AudioClip badBlipSound;

    public TMP_FontAsset goodGuyFont;
    public TMP_FontAsset badGuyFont;

    [HideInInspector] public bool isDeflecting;

    public bool isConverting;

    private void Start()
    {
        blipSound.pitch = Random.Range(.8f, 1.3f);
        blipSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isConverting && collision.GetComponent<EnemyShip>())
        {
            collision.GetComponent<EnemyShip>().TryConvert();
            Destroy(gameObject);
        }
        else if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            collision.GetComponent<Ship>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }

        if (collision.GetComponent<Planet>() && firingShip.GetComponent<PlayerShip>())
        {
            collision.GetComponent<Planet>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }

    public void GetFired(GameObject firer)
    {
        firingShip = firer;
    }

    public void SwitchToGoodGuyFont()
    {
        blipSound.clip = goodBlipSound;
        letter.font = goodGuyFont;
        letter.color = Color.white;
    }

    public void SwitchToBadGuyFont()
    {
        blipSound.clip = badBlipSound;
        letter.font = badGuyFont;
        letter.color = Color.red;
    }
}
