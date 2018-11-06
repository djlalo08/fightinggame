using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beater : MonoBehaviour {

    public float beatSpeed;
    public bool beat;
    public int grow; //-1 is shrink, 0 is still, 1 is grow
    public int counter;
    public float scaleUp;
    private float scaleDown;

    public float xSize;

    public Transform trans;

    // Use this for initialization
    void Start () {
        trans = this.GetComponent<Transform>();
        scaleDown = 1 / scaleUp;
    }
	
	// Update is called once per frame
	void Update () {
        if (grow == 1){
            if (counter<beatSpeed){
                trans.localScale = scaleUp*trans.localScale;
                counter++;
            }
            else{
                grow = -1;
                counter = 0;
            }
        }
        else if (grow == -1){
            if (counter < beatSpeed)
            {
                trans.localScale = scaleDown * trans.localScale;
                counter++;
            }
            else
            {
                grow = 0;
                counter = 0;
                beat = false;
            }
        }
        else{ //grow == 0//

        }

	}

    public void Beat(){
        if (!beat){
            beat = true;
            grow = 1;
            counter = 0;
        }
    }
}