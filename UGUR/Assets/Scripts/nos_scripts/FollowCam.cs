using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] GameObject obj;
    float diffX;
    float diffY;
    float diffZ;
    // Start is called before the first frame update
    void Start()
    {
        diffX = transform.position.x - obj.transform.position.x;
        diffY = transform.position.y - obj.transform.position.y;
        diffZ = transform.position.z - obj.transform.position.z; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((obj.transform.position.x + diffX),(obj.transform.position.y + diffY),(obj.transform.position.z + diffZ));
    }
}
