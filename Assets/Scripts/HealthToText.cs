﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthToText : MonoBehaviour {
    [SerializeField]
    Health health;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health != null)
        {
            text.text = "HP: " + health.Hp + " / " + health.MaxHp;
        }
	}
}
