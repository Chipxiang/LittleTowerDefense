using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var onCell = FindObjectsOfType<Cell>()[0];
        this.transform.position = new Vector3(onCell.transform.position.x, onCell.transform.position.y, onCell.transform.position.z + 0.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
