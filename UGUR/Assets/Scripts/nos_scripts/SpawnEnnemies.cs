using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
{
    private Transform target;

    [SerializeField] private GameObject enemy;

    [SerializeField] private Vector2 spawnArea;

    [SerializeField] private float spawnTimer;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        
        position += target.transform.position - new Vector3(0,0.8f,0);
        
        GameObject newEnemy = Instantiate(enemy, transform, true);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().targetDestination = target ;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.z = spawnArea.y * f;
        }
        else
        {
            position.z = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        
        position.y = 0.5f;
        
        return position;
    }

}
