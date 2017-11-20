﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        this.transform.position = new Vector3(4f, 0.7f, 0f);
    }

    // Use this for initialization
    internal void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            SliderManager.DeductHealth(collision.collider.GetComponent<Enemy>().Damage);
        }
        if (SliderManager.Gethealth() == 0 )
        {
            Time.timeScale = 0;
            Debug.Log("lose");

        }
    }
}
