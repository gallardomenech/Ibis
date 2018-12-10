using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Health : MonoBehaviour {

    [SerializeField] private int startingHealth = 20;
    [SerializeField] private float timeSinceLastHit = 0.5f;
    [SerializeField] private float dissapearSpeed = 2f;
    [SerializeField] private int currentHeath;

    private float timer = 0f;
    /*private Animator;*/
    private NavMeshAgent nav;
    private bool isAlive;
    private Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    private bool dissapearEnemy = false;

    public bool IsAlive
    {
        get { return isAlive; }
    }
	
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
        /*anim = GetComponent<Animator>();*/
        isAlive = true;
        currentHeath = startingHealth;
	}
	
	
	void Update () {
        timer += Time.deltaTime;

        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * dissapearSpeed * Time.deltaTime);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.tag == "PlayerWeapon")
            {
                takeHit();
                timer = 0f;
            }
        }
    }

    void takeHit()
    {
        if (currentHeath > 0)
        {
            //anim.Play("Hurt");
            currentHeath -= 10;

        }
        if (currentHeath <= 0)
        {
            isAlive = false;
            KillEnemy ();
        }
    }

    void KillEnemy()
    {
        capsuleCollider.enabled = false; // para quitar el collider
        nav.enabled = false;
        //anim.SetTrigger("Die");
        rigidbody.isKinematic = true; //para que el cuerpo se hunda

        StartCoroutine(removeEnemy());

    }

    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(2f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
