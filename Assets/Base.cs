using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            GameObject w = (GameObject)Instantiate((GameObject)Resources.Load("LOSE"));
            w.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
            w.GetComponent<Transform>().position = new Vector3(250, 150, 0);
            Debug.Log("lose");

        }
    }
}
