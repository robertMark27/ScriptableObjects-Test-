using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerData player;
    public Vector3 cameraOffset;

    public float cameraMoveSpeed;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.playerPosition + cameraOffset, cameraMoveSpeed * Time.deltaTime);
    }
}
