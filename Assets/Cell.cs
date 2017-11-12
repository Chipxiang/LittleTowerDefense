using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Menus
{
    public class Cell : MonoBehaviour
    {
        public static bool built_flag;
        public static bool path_flag;
        Transform pos;
        Mainmenu menu;
        // Use this for initialization
        void Start()
        {
            built_flag = true;
            path_flag = true;
            pos = gameObject.GetComponent<Transform>();

        }

        // Update is called once per frame
        void Update()
        {
        }
        private void OnMouseDown()
        {
            Debug.Log(gameObject.name);
            menu = new Mainmenu(pos, built_flag, path_flag);

        }


    }
}
