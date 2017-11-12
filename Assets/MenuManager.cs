using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Menus
{
    public partial class MenuManager : MonoBehaviour
    {
        public static Transform Canvas { get; private set; }
        private Mainmenu _main;
        //private Endmenu _pause;
        // Use this for initialization
        public MenuManager()
        {
            Canvas = GameObject.Find("Canvas").transform; // There should only ever be one canvas
        }
        public void ShowMainMenu()
        {
            _main = new Mainmenu();
            _main.Show();
        }

        public void HideMainMenu()
        {
            _main.Hide();
            _main = null;
        }

        /*public void Pause()
        {
            _pause = new PauseMenu();
            _pause.Show();
        }

        public void Unpause()
        {
            _pause.Hide();
            _pause = null;
        }
        */
        // Update is called once per frame
        private abstract class Menu
        {
            protected GameObject Go;
            public bool Showing { get; private set; }
            public virtual void Show()
            {
                Showing = true;
                Go.SetActive(true);
            }

            /// <summary>
            /// Hide this menu
            /// </summary>
            public virtual void Hide()
            {
                GameObject.Destroy(Go);
                Showing = false;
            }
        }

    }
}