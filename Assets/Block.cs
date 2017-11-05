using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {
    //a listener for licker
    //creat a menu
    private readonly Object builtmenu;
    public Block()
    {
        //builtmenu = Resources.Load("Menus/Builtmenu");



        InitializeButtons();
    }

    void InitializeButtons()
    { 
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("11111");

        }



    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
