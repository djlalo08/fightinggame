using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop:MonoBehaviour {

    //readonly int secsTosamples = 44100;

    public Beater beater;
    public Beater2 beater2;

    public static GameLoop instance = null;

    public int count;

    public int samplesTranspired;
    private int lastsampletime;

    public Text text1;
    public Text text2;

    public Player player1;
    public Player player2;

    public KeyListener player1Listener;
    public KeyListener player2Listener;

    static List<GameEvent> eventList = new List<GameEvent>();

    private AudioSource song;
    public int offset;
    public int songtimeSamples;
    public int beatSampleSize;
    public int epsilon;
    public int diff;

    // Use this for initialization
    void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }

        song = GetComponent<AudioSource>();

        text1.text = "";

        player1Listener = (player1.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener));
        player2Listener = (player2.isEnemy) ? (KeyListener)gameObject.AddComponent(typeof(AIListener)) : (KeyListener)gameObject.AddComponent(typeof(PlayerListener));
        player1.tieListener(player1Listener);
        player2.tieListener(player2Listener);
    }

    // Update is called once per frame
    void Update() {
        count++;
        respondToKeys();
        playerUpdates();

        songtimeSamples = song.timeSamples+offset;

        if(isBeat(songtimeSamples, beatSampleSize, epsilon)) { text1.text = "beat1!"; beater.Beat(); beater2.Beat(); } else text1.text = "";

        evaluatePending();
        samplesTranspired = songtimeSamples - lastsampletime;
        lastsampletime = songtimeSamples;
    }

    bool isBeat(int big, int breakSize, int epsilon) {
        diff = big % breakSize;
        return Mathf.Abs(diff) < epsilon;
    }

    //generates heart points depending on the heart-beat and pressure and moves being done
    void playerUpdates() {
        player1.update();
        player2.update();
        //for multiplayer consider alternating this order each update
    }

    //just set anything relevant to any keys presses. Activate any attack or move or anything like that
    public void respondToKeys() {
        player1Listener.update();
        player2Listener.update();
    }

    public static void addToList(GameEvent e) {
        eventList.Add(e);
    }

    public static void endEvent(GameEvent e) {
        eventList.Remove(e);
        e.agent.performing = null;
    }

    //check whether You got hit or not or whatever
    public void evaluatePending() {
        for(int i = eventList.Count-1; i>=0; i--) {
            eventList[i].update();
        }
    }

    public static void knockout(string name) {
        GameLoop.instance.text1.text = name + " has been knocked out!";
        Destroy(GameLoop.instance.gameObject);
        //win or lose depending on who got knocked out
    }

}
