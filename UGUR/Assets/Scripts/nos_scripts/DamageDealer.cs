using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    private bool attackStance = true;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("ennemy " + attackStance);

        }

        if (other.gameObject.CompareTag("Enemy") && AttackStance)
        {
            //Debug.Log("dégats");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    public bool AttackStance
    {
        get
        {
            return this.attackStance;
        }
        set
        {
            this.attackStance = value;
        }
    
    }
}
