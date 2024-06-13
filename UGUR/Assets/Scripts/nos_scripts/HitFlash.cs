using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    [SerializeField] float flashTime;
    private List<Transform> lesEnfants = new List<Transform>();
    private List<Color> lesCouleursOrigin = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            SkinnedMeshRenderer mesh= child.GetComponent<SkinnedMeshRenderer>();
            if (mesh != null){
                lesEnfants.Add(child);
                foreach (Material material in mesh.materials)
                {
                    lesCouleursOrigin.Add(material.color);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(){
        foreach (Transform child in lesEnfants)
        {
            SkinnedMeshRenderer mesh= child.GetComponent<SkinnedMeshRenderer>();
            foreach (Material material in mesh.materials)
            {
                material.color = Color.red;
            }
        }
        Invoke("NoHit",flashTime);
    }

    void NoHit(){
        int i=0;
        foreach (Transform child in lesEnfants)
        {
            SkinnedMeshRenderer mesh= child.GetComponent<SkinnedMeshRenderer>();
            foreach (Material material in mesh.materials)
            {
                
                material.color = lesCouleursOrigin[i];
                i +=1;
            }
            
        }
    }
}
