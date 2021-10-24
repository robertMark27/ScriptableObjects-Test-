using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    //Player damage event.
    public static event Action<float> DamagePlayer = delegate { };

    //All players data.
    public PlayerData player;

    //Players rigidbody component.
    private Rigidbody rb;

    //Player start material color.
    private Color startColorOfThePlayer;

    //Chcekc if the player is on the ground.
    private bool grounded;
    //Check if the player taking damage.
    private bool damaged;

    void Start()
    {
        //Set components to a veriables.
        rb = GetComponent<Rigidbody>();

        //Update player's health on start.
        player.playerHealth = 100;

        //Set the start color of the player.
        startColorOfThePlayer = player.playerMaterial.color;
    }

    void Update()
    {
        //Write the player position to the player data scriptable object.
        player.playerPosition = transform.position;

        if (!damaged)
        {
            //Movement control of the player.
            Movement();
            //Jump control of the player.
            Jump();
        }
    }

    //Player movement.
    void Movement()
    {
        //Get reference to the horizontal and vertical values.
        float Xmovement = Input.GetAxis("Horizontal");

        //Check if the player moving and multiply the horizontal value by player speed.
        if(Xmovement != 0)
            rb.velocity = new Vector3(Xmovement * player.playerSpeed, rb.velocity.y);
    }

    //Player jump.
    void Jump()
    {
        float Ymovement = Input.GetAxis("Vertical");
        if (grounded && Input.GetKeyDown(KeyCode.Space))
            rb.velocity = new Vector3(rb.velocity.x, player.playerJumpForce);
    }

    //Player Collisions.
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
    private void OnCollisionEnter(Collision collision)
    {
        //If the player collides with enemy.
        if(collision.transform.tag == "Enemy")
        {
            //Calculate the hit direction and add force to the player in the oposite direction.
            Vector3 dir = collision.transform.position - transform.position;
            print(collision.transform.position - transform.position);
            dir = -dir.normalized;
            rb.AddForce(dir * 10, ForceMode.Impulse);

            //Damage the player and playe the damage anomation.
            DamagePlayer(20);
            StartCoroutine(PlayerDamageAnim());
        }
    }

    //Player taking amage animation(Color change), and disable the movement.
    IEnumerator PlayerDamageAnim()
    {
        //Disable the movement.
        damaged = true;
        //Start the color blinking. 
        int i = 0;
        while (i < 3)
        {
            player.playerMaterial.color = new Color(0.13f, 0.11f, 0.18f);

            yield return new WaitForSeconds(0.1f);

            player.playerMaterial.color = startColorOfThePlayer;

            yield return new WaitForSeconds(0.1f);

            i++;
        }
        //Enable the movement.
        damaged = false;
    }
}
