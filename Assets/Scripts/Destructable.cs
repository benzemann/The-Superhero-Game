using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Destructable : MonoBehaviour {

    Health health;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		// Destroy object if health is 0
        if(health.Hp <= 0f)
        {
            Destroy(this.gameObject);
        }

	}
}
