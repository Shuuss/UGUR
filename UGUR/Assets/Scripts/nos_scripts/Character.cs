using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;

    public int currentHp = 1000;
    
    public int maxExp = 1000;

    public int currentExp = 0;

    public StatusBar hpBar;

    public ExpBar expBar;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.FindWithTag("HealthBar").GetComponentInChildren<StatusBar>();
        expBar = GameObject.FindWithTag("ExpBar").GetComponentInChildren<ExpBar>();
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
            //Debug.Log("Le personnage est mort PERDU");
        }
        hpBar.UpdateHealthBar(currentHp,maxHp);
    }
}
