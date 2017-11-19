using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remenu : MonoBehaviour {

    public static bool currentmenu;
    private readonly Object _menu;
    GameObject menu;
    // Use this for initialization
    void Start () {
        currentmenu = false;
        gameObject.SetActive(currentmenu);
    }
	public void display()
    {
        if(currentmenu == false)
        {
            currentmenu = true;
            gameObject.SetActive(currentmenu);
        }
        else
        {
            currentmenu = false;
            gameObject.SetActive(currentmenu);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentmenu == true)
        {
            gameObject.SetActive(currentmenu);
        }
        if(currentmenu == false)
        {
            gameObject.SetActive(currentmenu);
        }
    }
}
