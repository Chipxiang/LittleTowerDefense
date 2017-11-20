using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Menus
{
    public class Cell : MonoBehaviour
    {
        private  bool path_flag;
        private bool isbulint;//for build or for destory
        Transform cellpos;
        // Use this for initialization
        void Start()
        {
            isbulint = false;
            path_flag = true;
            cellpos = gameObject.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
        }
        private void OnMouseDown()
        {
            Debug.Log(gameObject.name);
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {

                    if (isbulint == false)
                    {
                    //var ff = Object.FindObjectOfType<Mainmenu>();
                    //Debug.Log(ff.name);
                    //Debug.Log(menu.name);
                         Debug.Log(gameObject.name+ "builtmenu");
                        var ff = GameObject.FindObjectOfType<Mainmenu>();
                        ff.dispalymenu(cellpos);
                        //var tmp = menu.GetComponent<Mainmenu>();
                        //tmp.dispalymenu();
                        /*var towerpos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
                        if (FindObjectOfType<TowerBlockCollection>().Spawn(towerpos))
                        {
                            Mainmenu me;
                            me = new Mainmenu();
                        }*/
                    }
                    else if (isbulint == true)
                {
                    var ff = GameObject.FindObjectOfType<Mainmenu>();
                    ff.hidemenu();
                    Debug.Log(gameObject.name + "removemenu");
                    var re = GameObject.FindObjectOfType<Remenu>();
                    re.dispalyremenu(cellpos);

                    Debug.Log(gameObject.name);
                    Debug.Log("removemenu");
                    //var ff = GameObject.FindObjectOfType<Mainmenu>();
                    //Debug.Log(ff.name);
                    //ff.dispalymenu(cellpos);
                    //var tmp = menu.GetComponent<Mainmenu>();
                    //tmp.dispalymenu();
                    var towerpos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
                    StartCoroutine(FindObjectOfType<TowerBlockCollection>().Spawn(towerpos));
                    if (!FindObjectOfType<TowerBlockCollection>().roadBlocker)
                    {
                        Mainmenu me;
                        me = new Mainmenu();
                    }
                }
               }
            else
            {
                Debug.Log("on UI");
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {

            }
        }

    }
}
