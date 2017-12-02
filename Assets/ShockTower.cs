using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShockTower : MonoBehaviour {
    public List<GameObject> enemyInRange;
    public float _lastHit = 0;
    private LayerMask layermask = 1 << 8;
    public Material _mat;
    private float line;
    // Use this for initialization
    void Start()
    {
        enemyInRange = new List<GameObject>();
    }
    IEnumerator DrawLine(Transform v1, Transform v2, Transform v3)
    {
        GetComponent<LineRenderer>().enabled = true;
        GetComponent<LineRenderer>().positionCount = 4;
        line = Time.time;
        while(Time.time-line < 0.3)
        {
            /*GL.PushMatrix();
            GL.LoadIdentity();
            GL.MultMatrix(FindObjectOfType<Camera>().worldToCameraMatrix*FindObjectOfType<Camera>().projectionMatrix);
            _mat.SetPass(0);
            GL.Begin(GL.LINES);
            if(v1!=null)
                GL.Vertex(v1.position);
            if(v2!=null)
                GL.Vertex(v2.position);
            if(v3!=null)
                GL.Vertex(v3.position);
            GL.End();
            GL.PopMatrix();*/
            //Debug.DrawLine(v1.position, v2.position, Color.blue);
            //Debug.DrawLine(v2.position, v3.position, Color.blue);

            if (v1 != null)
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, v1.position);
            }
                
            if (v2 != null)
                GetComponent<LineRenderer>().SetPosition(2, v2.position);
            if (v3 != null)
                GetComponent<LineRenderer>().SetPosition(3, v3.position);
            yield return null;
        }
        GetComponent<LineRenderer>().enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate () {
        /* = Resources.Load("ShockTowerMaterial", typeof(Material)) as Material;
        GL.PushMatrix();
        GL.LoadIdentity();
        //GL.MultMatrix(transform.localToWorldMatrix);
        //GL.LoadProjectionMatrix(FindObjectOfType<Camera>().projectionMatrix);
        //GL.modelview = FindObjectOfType<Camera>().worldToCameraMatrix;
        _mat.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Color(Color.blue);
        GL.Vertex( this.transform.position);
        GL.Vertex(FindObjectOfType<Base>().transform.position);
        GL.End();
        GL.PopMatrix();
        var positions = new Vector3[2];
        positions[0] = this.transform.position;
        positions[1] = FindObjectOfType<Base>().transform.position;
        GetComponent<LineRenderer>().SetPositions(positions);*/
        if (enemyInRange.Count != 0)
        {
            for (int i = 0; i < enemyInRange.Count; i++)
            {
                if (enemyInRange[i] == null)
                {
                    enemyInRange.RemoveAt(i);
                    i--;
                }
            }
            if (Time.time - _lastHit > 2 && enemyInRange.Count != 0)
            {
                _lastHit = Time.time;
                Transform v1, v2, v3;
                enemyInRange = enemyInRange.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
                v1 = enemyInRange[0].transform;
                enemyInRange[0].GetComponent<Enemy>().Health -= 5f;
                v2 = enemyInRange[0].transform;
                v3 = enemyInRange[0].transform;
                /*if (enemyInRange.Count > 1)
                {
                    v2 = enemyInRange[1].transform;
                    enemyInRange[1].GetComponent<Enemy>().Health -= 5f;
                }
                if (enemyInRange.Count >  2)
                {
                    v3 = enemyInRange[2].transform;
                    enemyInRange[2].GetComponent<Enemy>().Health -= 5f;
                }
                /*int nearest = 0;
               
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
                v1 = enemyInRange[nearest].transform;
                enemyInRange[nearest].GetComponent<Enemy>().Health -= 10f;
                v2 = enemyInRange[nearest].transform;
                v3 = enemyInRange[nearest].transform;
                if (enemyInRange.Count> nearest + 1)
                {
                    v2 = enemyInRange[nearest + 1].transform;
                    enemyInRange[nearest+1].GetComponent<Enemy>().Health -= 10f;
                }
                if (enemyInRange.Count > nearest + 2)
                {
                    v3 = enemyInRange[nearest + 2].transform;
                    enemyInRange[nearest + 2].GetComponent<Enemy>().Health -= 10f;
                }*/
                List<Collider> nearByEnemy = Physics.OverlapSphere(enemyInRange[0].transform.position, 1.5f, layermask).ToList();
                if (nearByEnemy.Count >= 2)
                {
                    nearByEnemy = nearByEnemy.OrderBy(x => Vector3.Distance(enemyInRange[0].transform.position, x.transform.position)).ToList();
                    v2 = nearByEnemy[1].transform;
                    nearByEnemy[1].GetComponent<Enemy>().Health -= 5f;
                    if (nearByEnemy.Count >= 3)
                    {
                        v3 = nearByEnemy[2].transform;
                        nearByEnemy[2].GetComponent<Enemy>().Health -= 5f;
                    }
                    /*List<Collider> nearByEnemy2 = Physics.OverlapSphere(nearByEnemy[1].transform.position, 1.5f, layermask).ToList();
                    if (nearByEnemy2.Count >= 2)
                    {
                        nearByEnemy2 = nearByEnemy2.OrderBy(x => Vector3.Distance(nearByEnemy[1].transform.position, x.transform.position)).ToList();
                        v3 = nearByEnemy2[1].transform;
                        if (v3 == v2 && nearByEnemy2.Count >= 3)
                        {
                            v3 = nearByEnemy2[2].transform;
                        }
                    }*/
                }
                
                /*int nearest1 = 1;
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
                //Debug.Log("Positions: "+v1.position+ v2.position +v3.position);
                StartCoroutine(DrawLine(v1, v2, v3));
            }
        }
		
	}
}
