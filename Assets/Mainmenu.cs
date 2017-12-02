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
        outpostion = gameObject.transform.position;
        //gameObject.transform.position = outpostion;
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
        //Debug.Log(gameObject.transform.position);
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

        var neww = gameObject.GetComponentsInChildren<Button>();
        //Debug.Log("name is "+newb.name);
        foreach (var newb in neww)
        {
            if (newb.name == "BuildBasic")
            {
                newb.onClick.AddListener(() => Basic());
            }
            else if (newb.name == "BuildFrozen")
            {
                newb.onClick.AddListener(() => Frozen());
            }
            else if (newb.name == "BuildShock")
            {
                newb.onClick.AddListener(() => Shock());
            }
        }
    }
    void Basic()
    {
        Debug.Log("rua");
        gameObject.transform.position = outpostion;
        StartCoroutine(FindObjectOfType<TowerBlockCollection>().Spawn(cellobj));
    }

    void Frozen()
    {
        Debug.Log("hhh");
        gameObject.transform.position = outpostion;
        StartCoroutine(FindObjectOfType<FreezeTowerBlockCollection>().Spawn(cellobj));
    }
    void Shock()
    {
        Debug.Log("fff");
        gameObject.transform.position = outpostion;
        StartCoroutine(FindObjectOfType<ShockTowerBlockCollection>().Spawn(cellobj));
    }

    public void hidemenu()
    {
        Debug.Log("hide");
        gameObject.transform.position = outpostion;
        Debug.Log(outpostion);
    }
}
