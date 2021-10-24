using UnityEngine;

[CreateAssetMenu(fileName = "New player", menuName ="Player")]
public class PlayerData : ScriptableObject
{
    //Player material
    public Material playerMaterial;

    //Player characteristics.
    public float playerHealth;
    public float playerSpeed;
    public float playerJumpForce;

    //Player other data
    public Vector3 playerPosition;
}
