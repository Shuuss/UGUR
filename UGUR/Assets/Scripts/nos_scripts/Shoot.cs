using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float frequency;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bulletPrefab;
    private Vector3 attackSize = new Vector3(2f,2f,2f);
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation * bulletPrefab.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
            timer = frequency;
        }
    }

    

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Inflige des dégâts à l'ennemi
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log((enemy.gameObject.name));
            }
        }
    }*/

    private void ApplyDamage(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log((colliders[i].gameObject.name));
        }
    }
}
