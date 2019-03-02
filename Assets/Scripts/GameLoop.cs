using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameLoop:MonoBehaviour {
    //160bpm offset:.49
    //pixelfighting3 offset: ~.135

    public float BPM;

    public Text winText;
    public Image winPanel;
    public Image flash;
    private int flashCount;

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
        p2Listener = (p2.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener2));
        p1.TieListener(p1Listener);
        p2.TieListener(p2Listener);
        p1Listener.isEnabled = p1.isEnabled;
        p2Listener.isEnabled = p2.isEnabled;
    }

    // Use this for initialization
    void Start() {
        flashCount = 0;

        GetComponent<AudioSource>().PlayDelayed(startTime+offset);
        InvokeRepeating("Beat", startTime, 60f/BPM);
    }

    // Update is called once per frame
    void Update() {
        p1queue += p1Listener.GetInput();
        p2queue += p2Listener.GetInput();

        if (flashCount >= 3) flash.GetComponent<Image>().enabled = false;
        flashCount++;
    }

    void Beat() {
        beater.Beat();
        heart1.Beat();
        heart2.Beat();
        flash.GetComponent<Image>().enabled = false;
        flashCount = 0;

        p1.Tire();
        p2.Tire();
        p1.Regen();
        p2.Regen();
        Action p1Action = p1.Parse(p1queue);
        Action p2Action = p2.Parse(p2queue);
        p1Action.Fatigue();
        p2Action.Fatigue();
        p1Action.Act();
        p2Action.Act();
        p1queue = "";
        p2queue = "";
        p1.heartPoints = Mathf.Min(p1.heartMax, p1.heartPoints);
        p2.heartPoints = Mathf.Min(p2.heartMax, p2.heartPoints);
        if (p1.heartPoints <= 0 ) Knockout (p1);
        if (p2.heartPoints <= 0) Knockout (p2);

        if (p1Listener is AIListener) ((AIListener)p1Listener).hasTyped = false;
        if (p2Listener is AIListener) ((AIListener)p2Listener).hasTyped = false;
    }

    public void Knockout(Player player) {
        winText.text = player.enemy.pName + " wins!!";
        winPanel.GetComponent<Image>().enabled = true;
        heart1.GetComponent<Image>().enabled = false;
        heart2.GetComponent<Image>().enabled = false;
        beater.GetComponent<Image>().enabled = false;
        CancelInvoke("Beat");
    }
}