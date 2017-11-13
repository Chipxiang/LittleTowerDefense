using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
       public class Mainmenu
        {
            private static Object _menu;
            GameObject newmenu;
            Canvas can;
             public Mainmenu(Transform pos,bool a,bool b)
            {
            if (!a)
            {
                _menu = Resources.Load("Menu/desmenu");
                can = Object.FindObjectOfType<Canvas>();
                Transform tmp = can.GetComponent<Transform>();
                newmenu = (GameObject)Object.Instantiate(_menu, pos.position, pos.rotation, tmp);
            }
            else
            {
                _menu = Resources.Load("Menu/Mainmenu");
                can = Object.FindObjectOfType<Canvas>();
                Transform tmp = can.GetComponent<Transform>();
                newmenu = (GameObject)Object.Instantiate(_menu, pos.position, pos.rotation, tmp);
                // TODO fill me in
            }
            }

            /// <summary>
            /// Add listeners to the MainMenu buttons
            /// </summary>
            private void InitializeButtons(bool a,bool b)
            {
                if (!b)
                {
                //变灰色
                }

                if (a && b)
                {
                var but = newmenu.GetComponent<Button>();
                if (but.name == "build1")
                {
                    //but.onClick.AddListener(() => Game.Ctx.StartGame()建塔);
                }
                  }


            }





        }
    }