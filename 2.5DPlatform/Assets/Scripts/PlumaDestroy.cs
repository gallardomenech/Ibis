using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumaDestroy : MonoBehaviour {

    public float lifeSpam = 2.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpam);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
