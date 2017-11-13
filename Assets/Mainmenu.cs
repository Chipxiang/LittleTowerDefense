using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
        public class Mainmenu 
        {
            private readonly Object _menu;
            GameObject menu;
            public Mainmenu(Transform pos,bool a,bool b)
            {
                _menu = Resources.Load("Menu/Mainmenu");
                Camera maincam = GameObject.FindObjectOfType<Camera>();
                var scr = GameObject.FindObjectOfType<Canvas>();
                Transform tran = scr.GetComponent<Transform>();
                Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);
                menu = (GameObject)GameObject.Instantiate(_menu, screenPos,pos.rotation, tran);
                InitializeButtons( menu);
                // TODO fill me in
            }

        /// <summary>
        /// Add listeners to the MainMenu buttons
        /// </summary>
        private void InitializeButtons(GameObject menu)
        {
            var newb = menu.GetComponentInChildren<Button>();

            if (newb.name == "Tower1")
            {
                newb.onClick.AddListener(test);
            }
           }
        void test()
        {
            Debug.Log("rua");
            Object.Destroy(menu);

        }
        }
    }