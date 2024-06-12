using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        x= transform.position.x;
        z= transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        


        transform.position = new Vector3(x+Input.GetAxis("Vertical")*Time.deltaTime* speed + Input.GetAxis("Horizontal")*Time.deltaTime*speed,transform.position.y,z+Input.GetAxis("Vertical")*Time.deltaTime* speed - Input.GetAxis("Horizontal")*Time.deltaTime*speed);
        x= transform.position.x;
        z= transform.position.z;

        FollowCursor();
        
           
    }

    void FollowCursor(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)){
        }
        float angle = Mathf.Atan2(raycastHit.point.x - transform.position.x,raycastHit.point.z- transform.position.z)*Mathf.Rad2Deg;
        //Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0, angle, 0);  
    }
}