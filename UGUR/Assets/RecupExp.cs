using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupExp : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip collectSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "exp")
        {
            Destroy(collider.gameObject);
            Collect();
        }   
    }

    void Collect(){
        src.clip = collectSound;
        src.Play();
    }
}
