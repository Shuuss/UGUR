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
        
        Vector3 mouseWorlPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouseWorlPosition);


        transform.position = new Vector3(x+Input.GetAxis("Vertical")*Time.deltaTime* speed + Input.GetAxis("Horizontal")*Time.deltaTime*speed,transform.position.y,z+Input.GetAxis("Vertical")*Time.deltaTime* speed - Input.GetAxis("Horizontal")*Time.deltaTime*speed);
        x= transform.position.x;
        z= transform.position.z;
        
        Vector2 mouse = new Vector2(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y- Screen.height/2);
        float angle = Mathf.Atan2(mouse.x,mouse.y)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle+45, 0);     
    }
}