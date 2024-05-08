using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    [SerializeField] WaveConfigSO wave;
    List<Transform> waypoints;
    int waypointIndex = 0;

    public float moveSpeed = 20;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        wave = enemySpawner.GetCurrentWave();
        waypoints = wave.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if ( transform.position == targetPosition )
            {
                waypointIndex++;
            }
        }

        else
        {
            waypointIndex = 0;
        }
    }
}
