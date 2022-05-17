using System;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidsGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public PlayerControllerArkanoid playerController;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public int paused = 0;
    public GameObject gameovertext;
    private void Start()
    {
        gameovertext.SetActive(false);
        var spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawnerArkanoids>();
        Spawn(spawnManager);
    }
    public void Restart()
    {
        this.lives--;
        checkLives();
    }

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == 0)
        {
            paused = 1;
            FreezeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == 1)
        {
            paused = 0;
            UnfreezeGame();
        }
        if(this.lives < 0 && Input.GetKeyDown(KeyCode.Return))
        {
            lives = 3;
            gameovertext.SetActive(false);
            checkLives();
        }
    }
    private void Respawn()
    {
        var spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawnerArkanoids>();
        Spawn(spawnManager);
        player.transform.position = Vector3.zero;
        spawnManager.ResumeSpawn();
    }

    private void Spawn(AsteroidSpawnerArkanoids spawnManager)
    {
        Instantiate(playerPrefab, spawnManager.transform);
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerControllerArkanoid>();
    }
    private void DeathManager()
    {
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AsteroidSpawnerArkanoids>().PauseSpawn();
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(gameObject);
        }
        Destroy(player);
    }
    private void FreezeGame()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<AsteroidControllerArkanoids>()).freeze();
        }

        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<BulletControllerArkanoids>()).freeze();
        }
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<PlayerControllerArkanoid>()).freeze();
        }
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("SpawnManager"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<AsteroidSpawnerArkanoids>()).freeze();
        }

    }
    private void UnfreezeGame()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<PlayerControllerArkanoid>()).unfreeze();
        }
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<BulletControllerArkanoids>()).unfreeze();
        }
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("SpawnManager"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<AsteroidSpawnerArkanoids>()).unfreeze();
        }
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            ((FreezeableArkanoids)gameObject.GetComponent<AsteroidControllerArkanoids>()).unfreeze();

        }
    }
    private void checkLives()
    {
        if (this.lives < 0)
        {
            DeathManager();
            gameovertext.SetActive(true);
        }
        else
        {
            DeathManager();
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }
}