using System;
using System.Collections;
using System.Collections.Generic;
using RPGCharacterAnimsFREE.Actions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform targetDestination;
    private GameObject targetGameObject;
    private Character targetCharacter;
    [SerializeField] private float speed;

    private Rigidbody rb;

    [SerializeField] private int hp = 100;
    [SerializeField] private int damage = 500;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetGameObject = targetDestination.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage()
    {
        hp -= damage;

        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
