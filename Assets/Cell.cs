using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Menus
{
    public class Cell : MonoBehaviour
    {
        public static bool path_flag;
        public static bool isbulint;//for build or for destory
        public static bool isclick;
        Transform cellpos;
        // Use this for initialization
        void Start()
        {
            isbulint = false;
            path_flag = true;
            isclick = false;
            cellpos = gameObject.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
        }
        private void OnMouseDown()
        {
            Debug.Log(gameObject.name);
            Debug.Log(isclick);
            if (isclick == false)
            {
                isclick = true;
                if (isbulint == false)
                {
                    //var ff = Object.FindObjectOfType<Mainmenu>();
                    //Debug.Log(ff.name);
                    //Debug.Log(menu.name);
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
                else if (isclick == true)
            {
                isclick = false;
                var ff = GameObject.FindObjectOfType<Mainmenu>();
                ff.hidemenu();

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
