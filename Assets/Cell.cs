using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Cell : MonoBehaviour
    {
        private  bool path_flag;
        public bool isBuilt;//for build or for destory
        public GameObject Toweron;
        Transform cellpos;
        // Use this for initialization
        void Start()
        {
            isBuilt = false;
            path_flag = true;
            cellpos = gameObject.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
        }
        private void OnMouseUpAsButton()
        {
        if(Time.timeScale == 0)
        {
            return;
        }
            Debug.Log(gameObject.name);
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
            var ttmp = FindObjectOfType<Remenu>();
            var outpos = ttmp.outpostion;
            var currpos = ttmp.transform.position;
           if (currpos != outpos)
            {
                Debug.Log(currpos);
                ttmp.hidemenu();
            }
                    if (isBuilt == false)
                    {
                    //var ff = Object.FindObjectOfType<Mainmenu>();
                    //Debug.Log(ff.name);
                    //Debug.Log(menu.name);
                         Debug.Log(gameObject.name+ "builtmenu");
                        var ff = GameObject.FindObjectOfType<Mainmenu>();
                        ff.dispalymenu(gameObject);

                    //var tmp = menu.GetComponent<Mainmenu>();
                    //tmp.dispalymenu();
                    /*var towerpos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
                    if (FindObjectOfType<TowerBlockCollection>().Spawn(towerpos))
                    {
                        Mainmenu me;
                        me = new Mainmenu();
                    }*/
                }
                    if (isBuilt == true)
                {

                if (currpos == outpos)
                {
                    /*vcurrposar ff = GameObject.FindObjectOfType<Mainmenu>();
                    ff.hidemenu();*/
                    Debug.Log(gameObject.name + "removemenu");
                    var re = GameObject.FindObjectOfType<Remenu>();
                    re.dispalyremenu(gameObject, Toweron);
                    Debug.Log(gameObject.name);
                    Debug.Log(re.name);
                    //var ff = GameObject.FindObjectOfType<Mainmenu>();
                    //Debug.Log(ff.name);
                    //ff.dispalymenu(cellpos);
                    //var tmp = menu.GetComponent<Mainmenu>();
                    //tmp.dispalymenu();
                }
                else
                {
                    currpos = outpos;
                }

                   /* if (!FindObjectOfType<TowerBlockCollection>().roadBlocker)
                    {
                        Mainmenu me;
                        me = new Mainmenu();
                    }*/
                }
               }
            else
            {
                Debug.Log("on UI");
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
           
        }

    }

