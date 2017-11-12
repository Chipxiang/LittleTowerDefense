using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
    public partial class MenuManager
    {
        private class Mainmenu : Menu
        {
            private readonly Object _menu;
            public Mainmenu()
            {
                _menu = Resources.Load("Menus/Mainmenu");
                Go = GameObject.Instantiate(_menu) as GameObject;
                // Debug.Log(Go.name);
                //Go.AddComponent<Button>();
                InitializeButtons();
                // TODO fill me in
            }

            /// <summary>
            /// Add listeners to the MainMenu buttons
            /// </summary>
            private void InitializeButtons()
            {
                var newb = Go.GetComponentsInChildren<Button>();
                foreach (Button but in newb)
                {
                    if (but.name == "build1") { }
                    //build a tower

                    if (but.name == "build2") { }
                        
                }
                Go.transform.SetParent(Canvas, false);//Canvas come from the UIma.cs.

                //newb.onClick.AddListener(() => Game.Ctx.StartGame());
                // TODO fill me in
            }





        }
    }
}