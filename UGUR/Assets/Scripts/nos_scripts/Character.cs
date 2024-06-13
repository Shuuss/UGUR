using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] private AudioClip collectSound;
    
    public int maxHp = 1000;

    public int currentHp = 920;
    
    public int maxExp = 1000;

    public int currentExp = 0;

    public StatusBar hpBar;

    public ExpBar expBar;

    public int level;
    
    [SerializeField] private GameObject levelUp;
    [SerializeField] Transform LevelUpSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.FindWithTag("HealthBar").GetComponentInChildren<StatusBar>();
        expBar = GameObject.FindWithTag("ExpBar").GetComponentInChildren<ExpBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= maxExp)
        {
            level += 1;
            src.clip = collectSound;
            src.Play();
            Instantiate(levelUp, LevelUpSpawnPoint.position,LevelUpSpawnPoint.rotation * levelUp.transform.rotation,LevelUpSpawnPoint.transform);
            currentExp = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 20)
        {
            SceneManager.LoadScene("GameOver");
            //Debug.Log("Le personnage est mort PERDU");
        }
        hpBar.UpdateHealthBar(currentHp,maxHp);
    }
}
