using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Player data.
    public PlayerData player;

    private void OnEnable()
    {
        PlayerScript.DamagePlayer += Damage;
    }

    private void OnDisable()
    {
        PlayerScript.DamagePlayer -= Damage;
    }

    private void Damage(float damage)
    {
        player.playerHealth -= damage;
    }
}
