using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.Menus
{
    public class Remenu : MonoBehaviour
    {
        private UnityEngine.Events.UnityAction m_MyFirstAction;
        public static bool currentmenu;
        private readonly Object _menu;
        GameObject menu;
        private Vector3 outpostion;
        bool isshow;
        Camera maincam;
        void Start()
        {
            outpostion = new Vector3(-100f, -300f, 0f);
            gameObject.transform.position = outpostion;
            gameObject.SetActive(true);
            isshow = false;
            maincam = FindObjectOfType<Camera>();
            //Debug.Log(outpostion);
            InitializeButtons();
        }
        public void dispalyremenu(GameObject cellobj)
        {
            var pos = cellobj.transform;
            if (gameObject.transform.position == outpostion)
            {
                Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);
                Debug.Log("screenPos"+screenPos);
                screenPos.x = screenPos.x + 600f;
                screenPos.y = screenPos.y + 500f;
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
        private void InitializeButtons()
        {
            var newb = gameObject.GetComponentInChildren<Button>();
            //Debug.Log("name is "+newb.name);
            if (newb.name == "Remove")
            {
                newb.onClick.AddListener(() => test());
            }
        }

        void test()
        {
            Debug.Log("destoryy~~");
            gameObject.transform.position = outpostion;
        }
        // Update is called once per frame
    }

}