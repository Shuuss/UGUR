using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] private AudioClip collectSound;

    public bool invincible = false;
    
    public int maxHp = 1000;

    public int currentHp = 920;
    
    public int maxExp = 1000;

    public int currentExp = 0;

    public StatusBar hpBar;

    public ExpBar expBar;

    public int level;

    private bool doShoot = false;

    private bool doRain = false;
    
    private bool doOrbite = false;
    
    [SerializeField] private GameObject levelUp;
    [SerializeField] Transform LevelUpSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        hpBar = GameObject.FindWithTag("HealthBar").GetComponentInChildren<StatusBar>();
        expBar = GameObject.FindWithTag("ExpBar").GetComponentInChildren<ExpBar>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= maxExp)
        {
            UnlockSpell(level);
            level += 1;
            //Time.timeScale = 0;
            //GameObject.FindWithTag("EditorOnly").GetComponent<Canvas>().enabled = true;
            
            src.clip = collectSound;
            src.Play();
            Instantiate(levelUp, LevelUpSpawnPoint.position,LevelUpSpawnPoint.rotation * levelUp.transform.rotation,LevelUpSpawnPoint.transform);
            currentExp = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincible)
        {
            return;
        }
        currentHp -= damage;

        if (currentHp <= 20)
        {
            SceneManager.LoadScene("GameOver");
            //Debug.Log("Le personnage est mort PERDU");
        }
        hpBar.UpdateHealthBar(currentHp,maxHp);
    }

    public void UnlockSpell(int choice)
    {
        if (choice == 0 && !doShoot)
        {
            GameObject.FindWithTag("Player").GetComponentInChildren<Shoot>().enabled = true;
            doShoot = true;
        }
        else if (choice == 1 && !doRain)
        {
            GameObject.FindWithTag("Player").GetComponentInChildren<AOE>().enabled = true;
            doRain = true;
        }
        else if(choice == 2 && !doOrbite)
        {
            GameObject.FindWithTag("Finish").GetComponentInChildren<test2>().enabled = true;
            
        }
        else
        {
            currentHp += 200;
            if (currentHp>maxHp)
            {
                currentHp = maxHp;
            }
            hpBar.UpdateHealthBar(currentHp,maxHp);
            
        }
        //GameObject.FindWithTag("EditorOnly").GetComponent<Canvas>().enabled = false;
        //Time.timeScale = 1;
    }


}
