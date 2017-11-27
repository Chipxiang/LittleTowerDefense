using UnityEngine;
using UnityEngine.UI;


public class GameImfomation : MonoBehaviour {
     static Text imfo;
    Object ene;
    static Transform spaw;
    static int info_wave;
    static int info_maxnum;
    static float info_damage;
    static float info_speed;
    static int info_valuse;
    static Text[] test;
    private Vector3 endPosition;
    // Use this for initialization
    void Start()
    {
        endPosition = new Vector3(-35, 20, 0);
        imfo = gameObject.GetComponent<Text>();
        //Updateinfo(1,10);
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        test = gameObject.GetComponentsInChildren<Text>();
    }
	
	// Update is called once per frame
	public static void Updateinfo (int wave) {
        var can = FindObjectOfType<Canvas>();
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        //imfo.text = "Wave" + string.Format("{0}", Assets.Code.Spawning.wave).PadLeft(1, '0') + "        " + "MonsterNumber" + string.Format("{0}", omnsternumber).PadLeft(1, '0');
    }
  /*  public static void hideinfo()
    {
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        //imfo.text = "";

    }*/
    public void infomoving(int nextwave,float timeratio)
    {
        Debug.Log(gameObject.transform.position);
        Debug.Log(timeratio);
        gameObject.transform.position = gameObject.transform.position + new Vector3(-20f,0f,0f)* timeratio;

    }
    public static void eclipse(int wave)
    {
        foreach (Text wavename in test)
        {
            if (wavename.name == "Text" + wave.ToString())
            {
                //Debug.Log(wavename.transform.position);
                //Debug.Log("Text" + wave.ToString() + "Fuck you");
                wavename.text = "";

            }
        }
    }
    public static void GetWaveInfo(int wave,int maxnum,float damage,float speed)
    {
        info_wave = wave;
        info_maxnum = maxnum;
        info_speed = speed;
        info_damage = damage;
        foreach (Text wavename in test)
        {
            if (wavename.name == "Text" + wave.ToString())
            {
                wavename.text = "Wave" + wave + "\r\n" + info_maxnum + "\r\n" + info_speed + "\r\n" + info_damage;

            }
        }
    }

}
