using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;

    public int currentHp = 1000;

    [SerializeField] private StatusBar hpBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Debug.Log("Le personnage est mort PERDU");
        }
        hpBar.UpdateHealthBar(currentHp,maxHp);
    }
}
