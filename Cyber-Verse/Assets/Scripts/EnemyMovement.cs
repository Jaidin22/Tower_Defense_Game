using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0; //current waypoint index we are pursuing

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);//Translation given by a vector, multiply by speed so the only thing controlling the speed is the speed we made at the top.
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed; //returns enemy back to start speed (once out of range of laser turret)
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];

    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }
}
