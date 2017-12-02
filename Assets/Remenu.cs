using UnityEngine;
using UnityEngine.UI;

    public class Remenu : MonoBehaviour
    {
        private UnityEngine.Events.UnityAction m_MyFirstAction;
        public static bool currentmenu;
        private readonly Object _menu;
        GameObject menu;
        public Vector3 outpostion;
        bool isshow;
        Camera maincam;
        GameObject tower;
         GameObject cellobject;
        void Start()
        {
            outpostion = gameObject.transform.position;
            //gameObject.transform.position = outpostion;
            gameObject.SetActive(true);
            isshow = false;
            maincam = FindObjectOfType<Camera>();
            //Debug.Log(outpostion);
            InitializeButtons();
        }
        public void dispalyremenu(GameObject cellobj, GameObject toweron)
        {
        cellobject = cellobj;
            tower = toweron;
            var pos = cellobj.transform;
            if (!isshow)
            {
                Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);
                Debug.Log("screenPos"+screenPos);
            //Debug.Log(pos.position);
            //Debug.Log(screenPos);
            screenPos.x = screenPos.x - 3f;
            gameObject.transform.position = screenPos;
            //gameObject.transform.position = pos.position;
            isshow = true;
            }
            else if (gameObject.transform.position != outpostion)
            {
                isshow = false;
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
            Destroy(tower);
            MoneyManager.AddMoney(18);
            Debug.Log("destoryy~~");
            gameObject.transform.position = outpostion;
            cellobject.GetComponent<Cell>().isBuilt = false;
            isshow = false;
    }

    public void hidemenu()
    {
        //Debug.Log("hide");
        gameObject.transform.position = outpostion;
        isshow = false;
        //Debug.Log(outpostion);

    }
    // Update is called once per frame
}

