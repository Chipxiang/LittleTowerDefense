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
            outpostion = new Vector3(-100f, -300f, 0f);
            gameObject.transform.position = outpostion;
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
            if (gameObject.transform.position == outpostion)
            {
                Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);
                Debug.Log("screenPos"+screenPos);
            //Debug.Log(pos.position);
            //Debug.Log(screenPos);
            screenPos.x = screenPos.x - 3f;
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
            Destroy(tower);
            Debug.Log("destoryy~~");
            gameObject.transform.position = outpostion;
        cellobject.GetComponent<Cell>().isBuilt = false;
    }

    public void hidemenu()
    {
        Debug.Log("hide");
        gameObject.transform.position = outpostion;
        Debug.Log(outpostion);

    }
    // Update is called once per frame
}

