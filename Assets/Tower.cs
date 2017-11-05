using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour {
    // Use this for initialization
    void Start () {
        this.transform.position = new Vector3(1 , 1, -0.7f);
	}
	void TurnToEnemy()
    {
        
    }
	// Update is called once per frame
	void Update() {
        RaycastHit[] hitinfo;
        var layermask = 1 << 8;
        hitinfo = Physics.SphereCastAll(transform.position, 0.5f, transform.forward, 1.5f, layermask);
        if (hitinfo.Length != 0)
        {
            int nearest = 0;
            for (int i = 0; i < hitinfo.Length; i++)
            {
                if (hitinfo[i].distance < hitinfo[nearest].distance)
                {
                    nearest = i;
                }
            }
            Vector3 relativePos = hitinfo[nearest].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            Quaternion rotationnew = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            transform.rotation = rotation;
            GetComponentInChildren<Gun>().FireAt(hitinfo[nearest].transform);
        }
	}
}
