using System.Collections;
using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Enemy damage event.
    public static event Action DamageEnemy;
    
    //Scriptable objects.
    public PlayerData player;
    public EnemyData enemy;

    //Player start material color.
    private Color startColorOfTheEnemy;

    //Enemy's rigidbody.
    private Rigidbody rb;

    //Allowed distance.
    public float followDistance;

    //Enemy grounded.
    private bool grounded;
    //Enemy take damage.
    private bool damaged;

    private void Start()
    {
        //Set the enemy health 100 on start.
        enemy.enemyHealth = 100;

        //Set the start color of the enemy.
        startColorOfTheEnemy = enemy.enemyMaterial.color;
    }

    private void Update()
    {
        //Get reference to enemy's rigidbody.
        rb = GetComponent<Rigidbody>();

        //Check if the player close to the enemy.
        if(Vector3.Distance(player.playerPosition, transform.position) <= followDistance)
        {
            FollowPlayer(player.playerPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            //Calculate the hit direction and add force to the player in the oposite direction.
            Vector3 dir = collision.transform.position - transform.position;
            print(collision.transform.position - transform.position);
            dir = -dir.normalized;
            rb.AddForce(dir * 10, ForceMode.Impulse);

            //Damage the enemy and play the damage animation.
            DamageEnemy?.Invoke();
            StartCoroutine(TakeDamageAnim());
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            grounded = false;
    }

    //Subscribe to the event.
    private void OnEnable()
    {
        PlayerScript.DamagePlayer += DamageThePlayer;
    }
    private void OnDisable()
    {
        PlayerScript.DamagePlayer -= DamageThePlayer;
    }

    private void DamageThePlayer()
    {
        player.playerHealth -= 20;
    }

    //Follow the player.
    private void FollowPlayer(Vector3 distance)
    {
        if (!damaged)
        {
            //Calculate the direction of the player and push the enemy there.
            Vector3 dir = distance - transform.position;
            rb.velocity = new Vector3(dir.normalized.x * enemy.enemySpeed, rb.velocity.y);

            //Start the jump method when player's y position grater then enemy's y position + 1.
            if (player.playerPosition.y > transform.position.y + 1)
            {
                Jump();
            }
        }
    }

    //Enemy jump method.
    private void Jump()
    {
        //Check if the enemy grounded.
        if (grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, enemy.enemyjumpForce);
        }
    }

    IEnumerator TakeDamageAnim()
    {
        //Disable the movement.
        damaged = true;
        //Start the color blinking. 
        int i = 0;
        while (i < 3)
        {
            enemy.enemyMaterial.color = new Color(0.13f, 0.11f, 0.18f);

            yield return new WaitForSeconds(0.1f);

            enemy.enemyMaterial.color = startColorOfTheEnemy;

            yield return new WaitForSeconds(0.1f);

            i++;
        }
        //Enable the movement.
        damaged = false;
    }
}
