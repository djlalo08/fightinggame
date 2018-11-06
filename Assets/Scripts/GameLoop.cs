using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameLoop:MonoBehaviour {

    public float BPM;

    public Beater3 beater3;
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
        p1queue = p1Listener.update();
        p2queue = p2Listener.update();
    }

    void Beat() {
        beater3.Beat();
        p1.Regen();
        p2.Regen();
        p1.Parse(p1queue).Act();
        p2.Parse(p2queue).Act();
        p1queue = "";
        p2queue = "";
    }

    

    public static void EndEvent(GameEvent e) {
        GameEvent b =e;
    }

    public static void Knockout(string name) {
        string b = name;
    }

    public static void AddToList(GameEvent e) {
        GameEvent b = e;
    }
}