using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] WaveConfigSO currentWave;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        foreach (WaveConfigSO waveConfig in waveConfigs)
        {
            currentWave = waveConfig;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                var spaceship = Instantiate(currentWave.GetEnemyPrefab(0),
                currentWave.GetStartingWaypoint().position,
                Quaternion.identity);
                spaceship.transform.localRotation = Quaternion.Euler(180, -90, 90);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
        }

        yield return new WaitForSeconds (timeBetweenWaves);

        
    }


}
