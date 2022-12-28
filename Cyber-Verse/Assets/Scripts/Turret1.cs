using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret1 : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Use Laser")]

    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowValue = .5f;
    public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform rotator;
    public float turnSpeed = 10f;
    public GameObject bulletpf;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke method 2 times per second. Do after 0 seconds, right at the beginning, repeating every 0,5 seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() // renewed search for a target, search through objects named enemy (enemy tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity; //Store shortest distance to enemy we have found so far. When we haven't found an enemy we have math.infirty so we have an infinte distance to enemy. 
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);//get distance of enemy
            if (distanceToEnemy < shortestDistance) // if enemy distance is less than value set for shortest distance...
            {
                shortestDistance = distanceToEnemy;//... set shortest distance to the distance from the enemy
                nearestEnemy = enemy; //Make the nearest enemy the enemy (to target)
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) // if we found an enemy and the shortest distance is within the range...
        {
            target = nearestEnemy.transform; // target = nearest enemy
            targetEnemy = nearestEnemy.GetComponent<Enemy>(); //sets target enemy to the nearest enemy of Enemy component
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.gameEnded)
        {
            this.enabled = false;
        }
        
        if (target == null)
        {
            lineRenderer.enabled = !useLaser;
            
            return;
        }

        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate; 
            }
            fireCountDown -= Time.deltaTime; 
        }

    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 0) * dir;
        Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
        Quaternion rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime * turnSpeed);
        rotator.rotation = rotation;
    }

    void Shoot()
    {
        
        GameObject bulletGO = (GameObject)Instantiate(bulletpf, firePoint.position, firePoint.rotation); 
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void Laser()
    {
        
        targetEnemy.DamageTarget(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowValue);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);


        Vector3 direction = firePoint.position - target.position;
    }
}
