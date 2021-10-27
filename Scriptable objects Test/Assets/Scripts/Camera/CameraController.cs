using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Player data
    public PlayerData player;

    //Camera custom offset.
    public Vector3 cameraOffset;

    //Camera position change speed.
    public float cameraMoveSpeed;

    void LateUpdate()
    {
        //Change camera position to player's position + offset.
        transform.position = Vector3.Lerp(transform.position, player.playerPosition + cameraOffset, cameraMoveSpeed * Time.deltaTime);
    }
}
