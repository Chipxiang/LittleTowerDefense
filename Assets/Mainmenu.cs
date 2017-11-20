using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
    {
        private UnityEngine.Events.UnityAction m_MyFirstAction;
            public static bool currentmenu;
            private readonly Object _menu;
            GameObject menu;
            public Vector3 outpostion;
            bool isshow;
            Camera maincam;
        GameObject cellobj;
        Transform cellpos;
            void Start()
        {

            outpostion = new Vector3(-50f,300f,0f);
            gameObject.transform.position = outpostion;
            gameObject.SetActive(true);
            isshow = false;
            maincam = FindObjectOfType<Camera>();
            //Debug.Log(outpostion);
            InitializeButtons();
        }
        public void dispalymenu(GameObject cell)
        {
            cellobj = cell;
            var pos = cell.GetComponent<Transform>();
            cellpos = pos;
            Debug.Log(gameObject.transform.position+ outpostion);
            if (gameObject.transform.position == outpostion)
            {
                if (MoneyManager.CurrentMoney < 20)
                    gameObject.GetComponentInChildren<Button>().interactable = false;
                else gameObject.GetComponentInChildren<Button>().interactable = true;
                Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);

            screenPos.x = screenPos.x - 3f;
            //screenPos.y = screenPos.y + 250f;
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
            if ( newb.name == "Built")
            {
                newb.onClick.AddListener(() => Test());
            }
        }
        void Test()
        {
            Debug.Log("rua");
            gameObject.transform.position = outpostion;
            StartCoroutine(FindObjectOfType<TowerBlockCollection>().Spawn(cellobj));
        }

        public void hidemenu()
        {
            Debug.Log("hide");
            gameObject.transform.position = outpostion;
            Debug.Log(outpostion);
        }
    }
