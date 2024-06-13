using System.Collections;
using System.Collections.Generic;
using System.Data;
using RPGCharacterAnimsFREE.Actions;
using UnityEngine;

public class AOE : MonoBehaviour
{
    [SerializeField] GameObject zone;
    DamageDealer weapon;
    
    [SerializeField] float frequency = 1;
    private float timer;
    private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<Transform>();
        weapon = zone.GetComponent<DamageDealer>();
        weapon.AttackStance = false;
        timer = frequency;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)){
        }
        transform.position= raycastHit.point;
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer <= 0)
        {
            Debug.Log("shoot");
            timer = frequency;
            ParticleSystem parts = zone.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(Instantiate(zone, spawnPoint.position, spawnPoint.rotation * parts.transform.rotation), totalDuration);
            //Debug.Log(weapon.AttackStance);

        }

        //Debug.Log(weapon.AttackStance);
    }
}
