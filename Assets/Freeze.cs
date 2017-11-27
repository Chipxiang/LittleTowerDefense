using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Freeze : MonoBehaviour {
    public int freezeLevel;
    public float _lastHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (freezeLevel > 0)
        {
            GetComponent<MeshRenderer>().material.color = new Color32(0, 97, 242, 1);
            GetComponent<NavMeshAgent>().speed = Mathf.Pow((2f / 3f), freezeLevel);
            if(Time.time - _lastHit >= 1)
            {
                _lastHit = Time.time;
                GetComponent<Enemy>().Health -= 5f * freezeLevel;
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 1);
            GetComponent<NavMeshAgent>().speed = 1;
        }
    }
}
