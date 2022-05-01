using UnityEngine;

public class AsteroidSpawnerArkanoids : MonoBehaviour, FreezeableArkanoids
{
    public AsteroidControllerArkanoids asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount=1;
    public float spawnDistance = 15.0f;
    public int paused = 0;
    public void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }
    
        
    
    private void Spawn()
    {
        if (paused == 1)
        {
            Debug.Log("paused");
            return;
        } 
       for (int i = 0; i < spawnAmount; i++)
       {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            AsteroidControllerArkanoids asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
        
    }
    public void PauseSpawn()
    {
        CancelInvoke();
    }
    public void ResumeSpawn()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    public void freeze()
    {
        paused = 1;
    }

    public void unfreeze()
    {
        paused = 0;
    }
}

