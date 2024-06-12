using UnityEngine;


public class LateFollow : MonoBehaviour
{
    [SerializeField] private Transform TargetToFollow;

    Vector3 Offset;

    void Start ()
    {
        Offset = transform.position - TargetToFollow.position;	
    }

    void LateUpdate ()
    {
        transform.position = TargetToFollow.position + Offset;	
    }
}