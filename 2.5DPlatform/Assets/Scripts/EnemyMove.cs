using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyMove : MonoBehaviour {

    [SerializeField] Transform player;
    private NavMeshAgent nav;


	// Use this for initialization
	void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Vector3.Distance (player.position, this. transform.position) < 6)
        {
            nav.SetDestination(player.position);
        }
	}
}
