using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour {
    private static float health;
    private static Slider slider;
    // Use this for initialization
    internal void Start () {
		slider = GetComponent<Slider>();
        UpdateSlider();
    }
    public static void DeductHealth(float points)
    {
        health -= points;
        if (health < 0)
            health = 0;
        UpdateSlider();
    }
    public static void UpdateSlider () {
        slider.value = health;
	}
}
