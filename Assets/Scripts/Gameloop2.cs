using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gameloop2 : MonoBehaviour {

    public Beater3 beater3;
    public float startTime;

    public Player player1;
    public Player player2;

    public KeyListener player1Listener;
    public KeyListener player2Listener;

    private void Awake() {
        player1Listener = (player1.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener));
        player2Listener = (player2.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener));
        player1.tieListener(player1Listener);
        player2.tieListener(player2Listener);
    }

    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().PlayDelayed(startTime);
        InvokeRepeating("Beat", startTime, 3f/8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Beat(){
        beater3.Beat();
    }
}
