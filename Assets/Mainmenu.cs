using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
        public class Mainmenu : MonoBehaviour
    {
        private UnityEngine.Events.UnityAction m_MyFirstAction;
            public static bool currentmenu;
            private readonly Object _menu;
            GameObject menu;
            Vector3 outpostion;
            bool isshow;
            Camera maincam;
            void Start()
        {
            outpostion = new Vector3(-35f,300f,0f);
            gameObject.SetActive(true);
            isshow = false;
            maincam = FindObjectOfType<Camera>();
            //Debug.Log(outpostion);
            InitializeButtons();
        }
        public void dispalymenu(Transform pos)
        {
            if (gameObject.transform.position == outpostion)
            {
                Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);
                screenPos.x = screenPos.x + 200f;
                screenPos.y = screenPos.y + 250f;
                //Debug.Log(pos.position);
                //Debug.Log(screenPos);
                gameObject.transform.position = screenPos;
                //gameObject.transform.position = pos.position;
            }
            else if (gameObject.transform.position != outpostion)
            {
                //isshow = false;
                gameObject.transform.position = outpostion;
            }

        }
        /// <summary>
        /// Add listeners to the MainMenu buttons
        /// </summary>
        private void InitializeButtons()
        {
            var newb = gameObject.GetComponentInChildren<Button>();
            //Debug.Log("name is "+newb.name);
            if ( newb.name == "Button")
            {
                newb.onClick.AddListener(() => test());
            }
        }
        void test()
        {
            Debug.Log("rua");
            gameObject.transform.position = outpostion;
        }
        public void hidemenu()
        {
            Debug.Log("hide");
            gameObject.transform.position = outpostion;
            Debug.Log(outpostion);
        }
    }

}