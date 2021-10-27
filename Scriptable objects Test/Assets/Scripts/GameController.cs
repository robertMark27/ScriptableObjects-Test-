using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Scriptable objects.
    public PlayerData player;

    //Spawn prefabs.
    public GameObject PlayerPrefab;
    public GameObject[] Enemys;

    //Spawn positions.
    public Transform playerSpawnPoint;
    public Transform[] enemySpawnPoint;

    //Enemy kill counter.
    [SerializeField] private int kills;

    //Waves.
    [SerializeField] private int waveNum;
    [SerializeField] private int killsToNextWave;
    private int addKills;
    private float breakTime;

    private void Start()
    {
        if (GameObject.Find("Player") == null)
            SpawnPlayer();
    }

    private void Update()
    {
        if (killsToNextWave == kills)
        {
            player.playerWaveBreak = true;
            player.playerBreakTime -= Time.deltaTime * 5;
        }

        if(player.playerBreakTime <= 0)
        {
            player.playerWaveBreak = false;
            player.playerBreakTime = 100;

            addKills += 2;
            waveNum++;
            killsToNextWave += addKills;
        }

        WaveStart();

    }

    private void OnEnable()
    {
        PlayerScript.Playerkill += SpawnPlayer;

        EnemyScript.EnemyKill += EnemysKilled;
    }
    private void OnDisable()
    {
        PlayerScript.Playerkill -= SpawnPlayer;

        EnemyScript.EnemyKill -= EnemysKilled;
    }

    //Player spawn.
    private void SpawnPlayer()
    {
        Instantiate(PlayerPrefab, playerSpawnPoint);
    }

    //Enemy spawn.
    private void SpawnEnemy()
    {
        for(int i = 0; i < 2; i++)
        {
            Instantiate(Enemys[i], enemySpawnPoint[i].position, Quaternion.identity);
        }
    }

    //Enemy kill count.
    private void EnemysKilled()
    {
        kills++;
        print(kills);
    }

    //Wave start.
    private void WaveStart()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && !player.playerWaveBreak)
            SpawnEnemy();
    }
}
