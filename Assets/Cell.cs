using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Menus
{
    public class Cell : MonoBehaviour
    {
        public static bool built_flag;
        public static bool path_flag;
        Transform tmp;
        // Use this for initialization
        void Start()
        {
            built_flag = true;
            path_flag = true;
            tmp = gameObject.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnMouseDown()
        {
            Debug.Log("click");
            var towerpos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
            if (FindObjectOfType<TowerBlockCollection>().Spawn(towerpos))
            {
                Mainmenu me;
                me = new Mainmenu(tmp.transform, built_flag, path_flag);
            }
            
            
        }
    }
}
