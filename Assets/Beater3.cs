using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beater3 : MonoBehaviour {

    public Transform trans;

    public Text t;
    private int beatCount = 1;

    public int counter;
    public bool isBig;

	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isBig && counter > 1){
            trans.localScale = .5f * trans.localScale;
            isBig = false;
            increment();
        }
        counter++;
	}

    public void Beat(){
        trans.localScale = 2 * trans.localScale;
        counter = 0;
        isBig = true;
    }

    public void increment() {
        beatCount = (beatCount >= 4) ? 1 : beatCount + 1;
        t.text = beatCount.ToString();
    }
}
