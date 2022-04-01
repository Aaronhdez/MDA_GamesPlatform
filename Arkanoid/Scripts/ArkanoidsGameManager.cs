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
        Instantiate(playerPrefab, spawnManager.transform);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerControllerArkanoid>();
        
    }
    public void Restart()
    {
        this.lives--;
        if (this.lives < 0)
        {
            GameOver();
        } else
        {
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawner>().PauseSpawn();
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Asteroid"))
            {
                Destroy(gameObject);
            }
            Destroy(player);
            Invoke(nameof(Respawn), this.respawnTime);
        }
        
    }

    private void GameOver()
    {
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawner>().PauseSpawn();
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(gameObject);
        }
        Destroy(player);
    }

    private void Respawn()
    {
        var spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawner>();
        Instantiate(playerPrefab, spawnManager.transform);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerControllerArkanoid>();
        player.transform.position = Vector3.zero;
        spawnManager.ResumeSpawn();
    }

}
