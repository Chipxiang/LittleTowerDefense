﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    private float baseHealth;
	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(4f, 0f, - 0.5f);
        baseHealth = 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            SliderManager.DeductHealth(5f);
        }
    }
<<<<<<< HEAD
    // Update is called once per frame
    void Update () {
		
	}
=======
        // Update is called once per frame
        void Update () {

    }
>>>>>>> 096f3840b56728d47b7456daa6ae4343884777cd
}
