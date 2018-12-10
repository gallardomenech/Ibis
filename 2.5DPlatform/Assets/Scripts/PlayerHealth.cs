using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int startingHealth = 90;
    [SerializeField] float timeSinceLastHit = 2.0f;
    [SerializeField] int currentHealth;

    private PlayerController playerController;
    private float timer = 0f;
    private Animator anim;

	public int CurrentHealth{
		get { return currentHealth; }
		set {
			if (value < 0)
				currentHealth = 0;
			else
				currentHealth = value;
		}
	}

	// Use this for initialization
	void Start ()
    {
        //anim = GetComponent<Animator> ();
        currentHealth = startingHealth;
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.tag == "weapon")
            {
                takeHit();
                timer = 0;
            }
        }
    }

    void takeHit()
    {
        if (currentHealth >= 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            //anim.Play ("Hurt"); --> esto activa la animacion de recibir daño
            currentHealth -= 30;
        }
        if (currentHealth <= 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            //anim.SetTrigger ("isDead"); --> esto activa la animacion de muerte
            playerController.enabled = false;
        }
    }


	public void PowerUpHealth () {
		if (currentHealth <= 60) {
			currentHealth += 30;
		} else if (currentHealth < startingHealth){
			CurrentHealth = startingHealth;
		}



	}

}
