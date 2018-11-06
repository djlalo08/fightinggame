using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beater2 : MonoBehaviour
{

    public float beatSpeed;
    public bool beat;
    public int grow; //-1 is shrink, 0 is still, 1 is grow
    public int counter;
    public float scaleUp;
    private float scaleDown;
    private bool sizeChanged;

    public Text t;
    private int beatCount;

    public Transform trans;

    // Use this for initialization
    void Start(){
        trans = this.GetComponent<Transform>();
        scaleDown = 1 / scaleUp;
    }

    // Update is called once per frame
    void Update() {
        if (grow == 1) {
            if (counter < beatSpeed) {
                if (!sizeChanged) {
                    trans.localScale = scaleUp * trans.localScale;
                    sizeChanged = true;
                    increment();
                }
                counter++;
            }
            else {
                grow = -1;
                counter = 0;
                sizeChanged = false;
            }
        }
        else if (grow == -1) {
            if (counter < beatSpeed) {
                if (!sizeChanged){
                    trans.localScale = scaleDown * trans.localScale;
                    sizeChanged = true;
                    increment();
                }
                counter++;
            }
            else {
                grow = 0;
                counter = 0;
                beat = false;
                sizeChanged = false;
            }
        }
        else { //grow == 0//

        }
    }

    public void increment(){
        beatCount = (beatCount >= 4) ? 1 : beatCount + 1;
        t.text = beatCount.ToString();
    }

    public void Beat(){
        if (!beat){
            beat = true;
            grow = 1;
            counter = 0;
        }
    }
}