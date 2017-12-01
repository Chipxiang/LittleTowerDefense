using UnityEngine;
using UnityEngine.UI;


public class GameImfomation : MonoBehaviour {
     static Text imfo;
    Object ene;
    static Transform spaw;
    static int info_wave;
    static int info_normnum;
    static float info_damage;
    static float info_speed;
    static int info_valuse;
    static Text test;
    static Transform icon;
    private Vector3 endPosition;
    // Use this for initialization
    void Start()
    {
        endPosition = new Vector3(-35, 20, 0);
        imfo = gameObject.GetComponent<Text>();
        //Updateinfo(1,10);
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        test = gameObject.GetComponentInChildren<Text>();
        icon = test.GetComponent<Transform>();

    }
    internal void FixedUpdate()
    {
        icon.position = icon.position - new Vector3(1f, 0f, 0f);
    }
    // Update is called once per frame
    public static void Updateinfo (int wave) {
        var can = FindObjectOfType<Canvas>();
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
    }
  /*  public static void hideinfo()
    {
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        //imfo.text = "";

    }*/
    public static void eclipse(int wave)
    {

                //Debug.Log(wavename.transform.position);
                //Debug.Log("Text" + wave.ToString() + "Fuck you");
                //wavename.text = "";

            
        
    }
    public static void GetWaveInfo(int wave,int normnum,float damage,float speed)
    {
        info_wave = wave;
        info_normnum = normnum;
        info_speed = speed;
        info_damage = damage;
        test.text = "Wave:" + wave + "\r\nNormal:" + info_normnum + "\r\nFast:" + info_speed + "\r\nfast:" + info_damage;
        var tra = test.GetComponent<Transform>();
        tra.position = new Vector3(Screen.width/2,30f,0f);   
    }
    public static bool isout()
    {
        if (icon.position.x < 0)
        {
            test.text = "";
            return true;
        }
        else
        {
            return false;
        }
    }
}
