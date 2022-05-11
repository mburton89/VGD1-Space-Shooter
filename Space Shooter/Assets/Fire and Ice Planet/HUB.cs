using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUB : MonoBehaviour
{
    public int healthRegenRate;

    private PlayerShip player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShip>())
        {
            collision.GetComponent<PlayerShip>().currentArmor += 1;
            player = collision.GetComponent<PlayerShip>();
            HUD.Instance.DisplayPlayerHealth(player.currentArmor, player.maxArmor);
        }
    }
}
