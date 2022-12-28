using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage = 50;

    public float explosionRadius = 0f;

    //public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //find direction bullet needs to point in
        Vector3 direction = (target.position - transform.position);
        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance)//if length of direction vector is less than the direction we're moving in the frame, we hit something
        {
            HitTarget();
            return;
        }
        //havent hit target. normalize to keep it at a constant speed(distance)
        transform.Translate(direction.normalized * distance, Space.World);
        //transform.LookAt(target);
    }

    void HitTarget()
    {

        //GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
       // Destroy(effect, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        //Might get an enemy that doesnt have enemy component

        if (e != null)
        {
            e.DamageTarget(damage);
        }
    }


    void Explode()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in hitObjects)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
}



