using System;
using System.Collections;
using System.Collections.Generic;
using RPGCharacterAnimsFREE.Actions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform targetDestination;
    private GameObject targetGameObject;
    private Character targetCharacter;
    [SerializeField] private float speed;

    [SerializeField] GameObject exp;

    private Rigidbody rb;
    
    private bool isKnockedBack = false;

    [SerializeField] private int hp = 100;
    [SerializeField] private int damage = 500;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetDestination = GameObject.FindWithTag("Player").transform;
        targetGameObject = targetDestination.gameObject;
        if (targetCharacter == null)
        {
            targetCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        Vector3 direction = new Vector3(targetDestination.position.x - transform.position.x,
            targetDestination.position.y - transform.position.y-2,
            targetDestination.position.z - transform.position.z).normalized;
        //(targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
        Look(direction);
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
        targetCharacter.TakeDamage(damage);
    }
    private IEnumerator ApplyKnockback(Vector3 direction, float force, float duration)
    {
        isKnockedBack = true;
        float elapsed = 0;
        while (elapsed < duration)
        {
            rb.AddForce(direction * (force * (1 - elapsed / duration)), ForceMode.Impulse);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isKnockedBack = false;
    }

    public void TakeDamage(int damageReceived)
    {
        hp -= damageReceived;
        
        GetComponent<HitFlash>().Hit();
        
        if (!isKnockedBack)
        {
            Vector3 direction = new Vector3(-(targetDestination.position.x - transform.position.x),
                targetDestination.position.y - transform.position.y-2,
                -(targetDestination.position.z - transform.position.z)).normalized;
            //rb.AddForce(direction * 1000,ForceMode.Impulse);
            float knockbackForce = 10f;
            float knockbackDuration = 0.2f;
            StartCoroutine(ApplyKnockback(direction, knockbackForce, knockbackDuration));
        }
        
        
        
        if (hp < 1)
        {   
            Destroy(gameObject);
        }
        
    }
    private void Look(Vector3 direction) {

        var rot = Quaternion.LookRotation(direction, Vector3.up);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 500 * Time.deltaTime);
    }

    void OnDestroy(){
        if(!this.gameObject.scene.isLoaded) return;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Instantiate(exp, pos, transform.rotation);
        

    }
}
