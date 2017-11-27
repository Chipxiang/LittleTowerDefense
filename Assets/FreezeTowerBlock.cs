using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreezeTowerBlock : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Freeze>().freezeLevel++;
            other.gameObject.GetComponent<Freeze>()._lastHit = Time.time;
            GetComponentInChildren<FreezeTower>().enemyInRange.Add(other.gameObject);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Freeze>().freezeLevel --;
            GetComponentInChildren<FreezeTower>().enemyInRange.Remove(other.gameObject);
        }
    }
    
}
