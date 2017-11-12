using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
       public class Mainmenu
        {
            private static Object _menu;
             public Mainmenu(Transform pos,bool a,bool b)
            {
                _menu = Resources.Load("Menu/Mainmenu");
                var can = Object.FindObjectOfType<Canvas>();
                Transform tmp = can.GetComponent<Transform>();
                var newmenu = (GameObject)Object.Instantiate(_menu, pos.position, pos.rotation, tmp);
                // TODO fill me in
            }

            /// <summary>
            /// Add listeners to the MainMenu buttons
            /// </summary>
            private void InitializeButtons(bool a,bool b)
            {
                if (a && b)
                { }
            }





        }
    }