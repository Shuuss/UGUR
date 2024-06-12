using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float duree;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,duree);

    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name != "Player" && collision.gameObject.name != "sol")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
    }
        
    
}
