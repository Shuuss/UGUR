using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] GameObject zone;

    private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)){
        }
        transform.position= raycastHit.point;  
        
        if (Input.GetMouseButtonDown(0)){
            ParticleSystem parts = zone.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(Instantiate(zone, spawnPoint.position, spawnPoint.rotation * parts.transform.rotation), totalDuration);

        }
    }
}
