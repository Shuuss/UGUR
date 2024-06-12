using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "exp"){
            var exp = collider.gameObject;
            Rigidbody rb = exp.GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(transform.position.x - exp.transform.position.x,
            transform.position.y - exp.transform.position.y-2,
            transform.position.z - exp.transform.position.z).normalized;
            //(targetDestination.position - transform.position).normalized;
            rb.velocity = direction * 100;
        }
    }
}
