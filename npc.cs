using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleNPC : MonoBehavior {
    Animator Animator;
    public GameObject cucumberToDestroy;
    public bool cherryHit = false;
    public float SmoothTime = 3.0f;
    public Vector3 smoothVelocity = Vector3.zero;
    public PointsManager _ptsManager;
    public HealthManager _healthManager;

    public AudioSource audioSource;
    public AudioClip eating;
    public AudioClip attack;
    public AudioClip die;

    void Start() 
    {
        animator = GetComponet<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update() 
    {
        if (cherryHit) {
            var cm = GameObject.Find("CucumberMan");
            var tf = cm.transform;
            this.GameObject.transform.LookAt(tf);

            Animator.Play("Standing Run");
            transform.position = Vector3.SmoothDamp(transform.position,tf.position,ref smoothVelocity,SmoothTime);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.GameObject.CompareTag("Player")) 
        {
            _healthManager = GameObject.Find("Health_Slider").GetComponent<HealthManager>();
            _healthManager.ReduceHealth();

            if (!cherryHit)
            {
                BeetlePatrol.isAttacking = true;

                var cm = GameObject.Find("CucumberMan");
                var tf = _cm.transform;
                this.GameObject.transform.LookAt(tf);

                Animator.Play("Attacking on Ground");
                StartCoroutine("DestroySelfOnGround");
            }
            else {
                Animator.Play("Standing Attack");
                StartCoroutine("DestroySelfStanding");
            }
        }
    }
    void OnTriggerEnter(Collider, theObject)    
    {
        if (theObject.gameObject.CompareTag("Cucumber")) 
        {
            cucumberToDestroy = theObject.GameObject;
            BeetlePatrol.isEating = true;
            animator.Play("Eating on Ground");
            audioSource.PlayOneShot(eating);
            StartCoroutine("DestroyCucumber");
        }
        else if(theObject.gameObject.CompareTag("Cherry"))
        {
            _ptsManager = gameObject.Find("Score_Value").GetComponent<PointsManager>();
            PointsManager.currentScore = PointsManager.currentScore + 10;
            BeetlePatrol.isAttacking = true;
            cherryHit = true;
            animator.Play("Stand");
            audioSource.PlayOneShot(attack);
        }
    }
    IEnumerator DestroyCucumber() 
    {
        yield return new WaitForSecondsRealTime (4);
        Destroy(cucumberToDestroy.gameObject);
        BeetlePatrol.isEating = false;
    }
    IEnumerator DestroySelfOnGround() 
    {
        yield return new WaitForSecondsRealTime (4);
        animator.Play("Die on Ground");
        audioSource.PlayOneShot(die);
        Destroy(cucumberToDestroy.gameObject);
    }
    IEnumerator DestroySelfStanding() 
    {
        yield return new WaitForSecondsRealTime (4);
        animator.Play("Die Standing");
        audioSource.PlayOneShot(die);
        Destroy(cucumberToDestroy.gameObject);
        cherryHit =  false;
    }
}

