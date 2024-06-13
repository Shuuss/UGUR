using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 2;
    [SerializeField] float radius = 1;
    [SerializeField] float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Truc qui tourne
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y;
        float z = target.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x,y,z);

        angle += speed * Time.deltaTime;
    }
}
