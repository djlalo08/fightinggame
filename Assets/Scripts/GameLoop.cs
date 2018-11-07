using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameLoop:MonoBehaviour {

    public float BPM;

    public Text winText;
    public Image winPanel;

    public Beater beater;
    public Beater heart1;
    public Beater heart2;

    public float startTime;
    public float offset;//starts music a little later/earlier

    public Player p1;
    public Player p2;

    KeyListener p1Listener;
    KeyListener p2Listener;

    string p1queue;
    string p2queue;

    private void Awake() {
        p1Listener = (p1.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener));
        p2Listener = (p2.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener));
        p1.TieListener(p1Listener);
        p2.TieListener(p2Listener);
    }

    // Use this for initialization
    void Start() {
        GetComponent<AudioSource>().PlayDelayed(startTime+offset);
        InvokeRepeating("Beat", startTime, 60f/BPM);
    }

    // Update is called once per frame
    void Update() {
        p1queue += p1Listener.GetInput();
        p2queue += p2Listener.GetInput();
    }

    void Beat() {
        beater.Beat();
        heart1.Beat();
        heart2.Beat();

        p1.Tire();
        p2.Tire();
        p1.Regen();
        p2.Regen();
        p1.Parse(p1queue).Act();
        p2.Parse(p2queue).Act();
        p1queue = "";
        p2queue = "";
        p1.heartPoints = Mathf.Min(p1.heartMax, p1.heartPoints);
        p2.heartPoints = Mathf.Min(p2.heartMax, p2.heartPoints);
        if (p1.heartPoints <= 0 ) Knockout (p1.enemy.pName);
        if (p2.heartPoints <= 0) Knockout (p2.enemy.pName);
    }
    
    public void Knockout(string name) {
        winText.text = name + " wins!!";
        winPanel.GetComponent<Image>().enabled = true;
        beater.GetComponent<Image>().enabled = false;
        CancelInvoke("Beat");
    }
}