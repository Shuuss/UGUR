using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationEtat : MonoBehaviour
{
    Animator animator;
    float currentAngle;

    [SerializeField] float speed;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject slashPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentAngle = transform.rotation.eulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {
        bool avance = false;
        bool recul = false;
        bool gauche = false;
        bool droite = false;

        float angle = transform.rotation.eulerAngles.y-currentAngle;
        bool orienteAvant = (angle < 45) || (angle > 315);
        bool orienteArriere = (angle < 225) && (angle > 135);
        bool orienteGauche = (angle > 225) && (angle < 315);
        bool orienteDroite = (angle > 45) && (angle < 135);
        // avance
        if (Input.GetAxis("Vertical") > 0 && orienteAvant){
            animator.SetBool("enAvant",true);
            avance = true;
        }
        if ((Input.GetAxis("Vertical") < 0) && orienteArriere){
            animator.SetBool("enAvant",true);
            avance = true;
        }
        if ((Input.GetAxis("Horizontal") > 0) && orienteDroite){
            animator.SetBool("enAvant",true);
            avance = true;
        }
        if ((Input.GetAxis("Horizontal") < 0) && orienteGauche){
            animator.SetBool("enAvant",true);
            avance = true;
        }
        if (!avance){
            animator.SetBool("enAvant",false);
        }

        // recul
        if (Input.GetAxis("Vertical") > 0 && orienteArriere){
            animator.SetBool("enArriere",true);
            recul = true;
        }
        if ((Input.GetAxis("Vertical") < 0) && orienteAvant){
            animator.SetBool("enArriere",true);
            recul = true;
        }
        if ((Input.GetAxis("Horizontal") > 0) && orienteGauche){
            animator.SetBool("enArriere",true);
            recul = true;
        }
        if ((Input.GetAxis("Horizontal") < 0) && orienteDroite){
            animator.SetBool("enArriere",true);
            recul = true;
        }
        if (!recul){
            animator.SetBool("enArriere",false);
        }
        
        // gauche
        if (Input.GetAxis("Vertical") > 0 && orienteDroite){
            animator.SetBool("aGauche",true);
            gauche = true;
        }
        if ((Input.GetAxis("Vertical") < 0) && orienteGauche){
            animator.SetBool("aGauche",true);
            gauche = true;
        }
        if ((Input.GetAxis("Horizontal") > 0) && orienteArriere){
            animator.SetBool("aGauche",true);
            gauche = true;
        }
        if ((Input.GetAxis("Horizontal") < 0) && orienteAvant){
            animator.SetBool("aGauche",true);
            gauche = true;
        }
        if (!gauche){
            animator.SetBool("aGauche",false);
        }


        // droite
        if (Input.GetAxis("Vertical") > 0 && orienteGauche){
            animator.SetBool("aDroite",true);
            droite = true;
        }
        if ((Input.GetAxis("Vertical") < 0) && orienteDroite){
            animator.SetBool("aDroite",true);
            droite = true;
        }
        if ((Input.GetAxis("Horizontal") > 0) && orienteAvant){
            animator.SetBool("aDroite",true);
            droite = true;
        }
        if ((Input.GetAxis("Horizontal") < 0) && orienteArriere){
            animator.SetBool("aDroite",true);
            droite = true;
        }
        if (!droite){
            animator.SetBool("aDroite",false);
        }
        // attack
        if (Input.GetMouseButtonDown(0)){
            animator.SetBool("attack",true);
            ParticleSystem parts = slashPrefab.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(Instantiate(slashPrefab, spawnPoint.position, spawnPoint.rotation * slashPrefab.transform.rotation, spawnPoint.transform), totalDuration);
        }
        if (!Input.GetMouseButtonDown(0)){
            animator.SetBool("attack",false);
        }
    }
}
