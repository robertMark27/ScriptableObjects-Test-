using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    //All the players data
    public PlayerData player;

    private Rigidbody rb;
    void Start()
    {
        //Set components to a veriables.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //Get reference to the horizontal and vertical values.
        float Xmovement = Input.GetAxis("Horizontal");
        float Ymovement = Input.GetAxis("Vertical");

        //Check if the player moving and multiply the horizontal value by player speed.
        if(Xmovement != 0)
            rb.velocity = new Vector3(Xmovement * player.playerSpeed, rb.velocity.y);
    }
}
