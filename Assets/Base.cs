using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private float baseHealth;
    // Use this for initialization
    void Start()
    {
        this.transform.position = new Vector3(4f, 0f, -1.5f);
        baseHealth = 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            SliderManager.DeductHealth(5f);
        }
    }
}