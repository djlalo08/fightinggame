using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {
    
    public Player player;
    public Slider slider;
    public Slider maxHealth;
    public Beater heart;

	// Use this for initialization
	void Start () {
        slider.maxValue = player.heart.MAX;
        maxHealth.maxValue = player.heart.MAX;
	}
	
	// Update is called once per frame
    void Update () {
        slider.value = player.heartPoints;
        maxHealth.value = player.heartMax;
        //heart.size = 1f/(player.heartPoints/220f);
	}
}
