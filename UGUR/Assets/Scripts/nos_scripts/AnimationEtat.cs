using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationEtat : MonoBehaviour
{
    Animator animator;
    float currentAngle;
    
    AnimatorClipInfo[] animatorinfo;
    string current_animation;
    
    [SerializeField] float frequency;
    private float timer;
    private DamageDealer weapon;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject slashPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentAngle = transform.rotation.eulerAngles.y;
        weapon = this.GetComponentInChildren<DamageDealer>();

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
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
        /*else if (weapon.attackStance && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            weapon.attackStance = false;
        }*/
        else
        {
            animator.SetBool("attack",false);
        }
        
    }

    private void Attack()
    {
        animator.SetBool("attack",true);
        animatorinfo = this.animator.GetCurrentAnimatorClipInfo(0);
        ParticleSystem parts = slashPrefab.GetComponent<ParticleSystem>();
        float totalDuration = parts.duration + parts.startLifetime;
        StartCoroutine(Stance(totalDuration));
        Debug.Log(weapon.attackStance);
        Destroy(Instantiate(slashPrefab, spawnPoint.position, spawnPoint.rotation * slashPrefab.transform.rotation, spawnPoint.transform), totalDuration);
        timer = frequency;
        

    }
    
    private IEnumerator Stance(float duration)
    {
        weapon.attackStance = false;
        yield return new WaitForSeconds(duration);
        weapon.attackStance = true;
        yield return new WaitForSeconds(duration);
        weapon.attackStance = false;
        
    }
}
