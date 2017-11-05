using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    // Use this for initialization
        private float baseHealth;
        void Start()
        {
            this.transform.position = new Vector3(4f, 0f, -1.5f);
        }

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            SliderManager.DeductHealth(5f);
        }
    }
}
