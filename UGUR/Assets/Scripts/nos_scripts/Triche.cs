using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triche : MonoBehaviour
{
    private Character player;

    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInChildren<Character>();
        timer = GameObject.FindWithTag("timer").GetComponentInChildren<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("e appuyé");
            player.currentExp += 200;
            player.expBar.UpdateExpBar(player.currentExp,player.maxExp);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("t appuyé");
            timer.time += 60;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            player.invincible = !player.invincible;
        }
    }
}
