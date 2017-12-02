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
    int[] Tower_Val;
    void Start()
    {
        outpostion = gameObject.transform.position;
        //gameObject.transform.position = outpostion;
        gameObject.SetActive(true);
        isshow = false;
        maincam = FindObjectOfType<Camera>();
        //Debug.Log(outpostion);
        InitializeButtons();
        Tower_Val = new int[3] { 20, 25, 25 };
    }
    public void dispalymenu(GameObject cell)
    {
        cellobj = cell;
        var pos = cell.GetComponent<Transform>();
        cellpos = pos;
        //Debug.Log(gameObject.transform.position);
        Button[] bu = gameObject.GetComponentsInChildren<Button>();
        foreach (var butt in bu){
            if (butt.name == "BuildBasic")
            {
                if (MoneyManager.CurrentMoney < 20)
                {
                    butt.interactable = false;
                }
                else butt.interactable = true;
            }
            else if (butt.name == "BuildFrozen")
            {
                if (MoneyManager.CurrentMoney < 25)
                {
                    butt.interactable = false;
                }
                else butt.interactable = true;
            }
            else if (butt.name == "BuildShock")
            {
                if (MoneyManager.CurrentMoney < 25)
                {
                    butt.interactable = false;
                }
                else butt.interactable = true;
            }
        }
        if (!isshow)
        {
           /* if (MoneyManager.CurrentMoney < 20)
                gameObject.GetComponentInChildren<Button>().interactable = false;
            else gameObject.GetComponentInChildren<Button>().interactable = true;*/
            Vector3 screenPos = maincam.WorldToScreenPoint(pos.position);

        screenPos.x = screenPos.x - 3f;
        //screenPos.y = screenPos.y + 250f;
        //Debug.Log(pos.position);
        //Debug.Log(screenPos);
        gameObject.transform.position = screenPos;
            isshow = true;
            //gameObject.transform.position = pos.position;
        }
        else//(gameObject.transform.position != outpostion)
        {
            isshow = false;
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
        isshow = false;
        gameObject.transform.position = outpostion;
        StartCoroutine(FindObjectOfType<TowerBlockCollection>().Spawn(cellobj));
    }

    void Frozen()
    {
        isshow = false;
        Debug.Log("hhh");
        gameObject.transform.position = outpostion;
        StartCoroutine(FindObjectOfType<FreezeTowerBlockCollection>().Spawn(cellobj));
    }
    void Shock()
    {
        Debug.Log("fff");
        isshow = false;
        gameObject.transform.position = outpostion;
        StartCoroutine(FindObjectOfType<ShockTowerBlockCollection>().Spawn(cellobj));
    }

    public void hidemenu()
    {
        Debug.Log("hide");
        isshow = false;
        gameObject.transform.position = outpostion;
        Debug.Log(outpostion);
    }
}
