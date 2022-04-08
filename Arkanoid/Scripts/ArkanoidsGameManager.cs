using System;
using UnityEngine;

public class ArkanoidsGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public PlayerControllerArkanoid playerController;
    public int lives = 3;
    public float respawnTime = 3.0f;
    private void Start()
    {
        var spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawner>();
        Spawn(spawnManager);
    }
    public void Restart()
    {
        this.lives--;
        if (this.lives < 0)
        {
            DeathManager();
        } else
        {
            DeathManager();
            Invoke(nameof(Respawn), this.respawnTime);
        }
        
    }  
    private void Respawn()
    {
        var spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawner>();
        Spawn(spawnManager);
        player.transform.position = Vector3.zero;
        spawnManager.ResumeSpawn();
    }

    private void Spawn(AsteroidSpawner spawnManager)
    {
        Instantiate(playerPrefab, spawnManager.transform);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerControllerArkanoid>();
    }
    private void DeathManager()
    {
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawner>().PauseSpawn();
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(gameObject);
        }
        Destroy(player);
    }
}
