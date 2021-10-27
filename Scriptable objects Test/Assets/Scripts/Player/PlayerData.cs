using UnityEngine;

[CreateAssetMenu(fileName = "New player", menuName ="Player")]
public class PlayerData : ScriptableObject
{
    //Player characteristics.
    public float playerHealth;
    public float playerSpeed;
    public float playerJumpForce;
    public float playerBulletSpeed;
    public float playerBreakTime;

    public bool playerWaveBreak;

    //Player other data
    public Material playerMaterial;
    public Vector3 playerPosition;
    public GameObject bullet;
}
