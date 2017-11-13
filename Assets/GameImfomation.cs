using UnityEngine;
using UnityEngine.UI;


public class GameImfomation : MonoBehaviour {
     static Text imfo;
    Object ene;
    static Transform spaw;
    // Use this for initialization
    void Start()
    {
        imfo= gameObject.GetComponent<Text>();
        Updateinfo();
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        Debug.Log(spaw.childCount);
    }
	
	// Update is called once per frame
	public static void Updateinfo () {
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
        imfo.text = "Wave" + string.Format("{0}", Assets.Code.Spawning.wave).PadLeft(1, '0') + "        " + "MonsterNumber" + string.Format("{0}", spaw.childCount).PadLeft(1, '0');
    }
}
