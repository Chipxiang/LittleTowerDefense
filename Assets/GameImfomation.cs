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
    }
	
	// Update is called once per frame
	public static void Updateinfo ()
	{
		var _enemySpeed = FindObjectOfType<Enemy>().Speed;
		var _enemyDamage = FindObjectOfType<Enemy>().Damage;
		
        spaw = FindObjectOfType<Assets.Code.Spawning>().GetComponent<Transform>();
		imfo.text = "Wave" + string.Format("{0}", Assets.Code.Spawning.wave) + "\n"
		            + "MonsterNumber" + string.Format("{0}", spaw.childCount) + "\n"
		            + "Enemy Speed: " + string.Format("{0}", _enemySpeed) + "\n"
		            + "Enemy Damage: " + string.Format("{0}", _enemyDamage);
	}
}
