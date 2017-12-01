using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockTower : MonoBehaviour {
    public List<GameObject> enemyInRange;
    public float _lastHit = 0;
    private LayerMask layermask = 1 << 8;
    public Material _mat;
    // Use this for initialization
    void Start()
    {
        enemyInRange = new List<GameObject>();
        _mat = Resources.Load("ShockTowerMaterial", typeof(Material)) as Material;

    }
    IEnumerator DrawLine(Transform v1, Transform v2, Transform v3)
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix();
        _mat.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Vertex3(v1.position.x, v1.position.y, v1.position.z);
        GL.Vertex3(v2.position.x, v2.position.y, v2.position.z);
        GL.Vertex3(v3.position.x, v3.position.y, v3.position.z);
        GL.End();
        GL.PopMatrix();
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void FixedUpdate () {
        if(enemyInRange.Count != 0)
        {
            if (enemyInRange[0] == null)
                enemyInRange.RemoveAt(0);
            else if (Time.time - _lastHit > 2)
            {
                _lastHit = Time.time;
                Transform v1, v2, v3;
                int nearest = 0;
                for (int i =0;i < enemyInRange.Count; i++)
                {
                    if (enemyInRange[i] == null)
                    {
                        enemyInRange.RemoveAt(i);
                        i--;
                    } 
                    else
                    {
                        var distance = Vector3.Distance(enemyInRange[i].transform.position, transform.position);
                        var nearestDistance = Vector3.Distance(enemyInRange[nearest].transform.position, transform.position);
                        if (distance < nearestDistance)
                        {
                            nearest = i;
                        }
                    }
                }
                v1 = enemyInRange[0].transform;
                v2 = enemyInRange[0].transform;
                v3 = enemyInRange[0].transform;
                if (enemyInRange.Count>1)
                    v2 = enemyInRange[1].transform;
                if(enemyInRange.Count>2)
                    v3 = enemyInRange[2].transform;
                /*Collider[] nearByEnemy = Physics.OverlapSphere(enemyInRange[nearest].transform.position, 1.5f, layermask);
                int nearest1 = 1;
                if (nearByEnemy.Length >= 2)
                {
                    for (int i = 1; i < nearByEnemy.Length; i++)
                    {
                        var distance = Vector3.Distance(nearByEnemy[i].transform.position, enemyInRange[nearest].transform.position);
                        var nearestDistance = Vector3.Distance(nearByEnemy[nearest1].transform.position, enemyInRange[nearest].transform.position);
                        if (distance < nearestDistance)
                        {
                            nearest1 = i;
                        }
                    }
                    v2 = nearByEnemy[nearest1].transform;
                    int nearest2 = 0;
                    Collider[] nearByEnemy2 = Physics.OverlapSphere(nearByEnemy[nearest1].transform.position, 1.5f, layermask);
                    if (nearByEnemy2.Length >= 1)
                    {
                        for (int i = 1; i < nearByEnemy2.Length; i++)
                        {
                            var distance = Vector3.Distance(nearByEnemy2[i].transform.position, nearByEnemy[nearest1].transform.position);
                            var nearestDistance = Vector3.Distance(nearByEnemy2[nearest2].transform.position, nearByEnemy[nearest1].transform.position);
                            if (distance < nearestDistance)
                            {
                                nearest2 = i;
                            }
                        }
                        v3 = nearByEnemy[nearest1].transform;
                    }
                }*/
                Debug.Log("Positions: "+v1.position+ v2.position +v3.position);
                StartCoroutine(DrawLine(v1, v2, v3));
            }
        }
		
	}
}
