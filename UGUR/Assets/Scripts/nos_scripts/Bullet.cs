using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float duree;
    
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,duree);

    }
   /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ennemy" )
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
    }*/

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("Enemy"))
       {
           Enemy enemy = other.gameObject.GetComponent<Enemy>();
           if (enemy != null)
           {
               enemy.TakeDamage(damage);
               Debug.Log("toucheyy");
           }
       }
   }
   
        
    
}
