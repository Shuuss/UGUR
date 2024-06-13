using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpBall : MonoBehaviour
{
    [SerializeField] private int qteExp;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindWithTag("Player"))
        {
            Character player = other.gameObject.GetComponentInChildren<Character>();
            player.currentExp += qteExp;
            player.expBar.UpdateExpBar(player.currentExp,player.maxExp);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
