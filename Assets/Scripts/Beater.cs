using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beater : MonoBehaviour {

    public Transform trans;

    public Text t;
    private int beatCount = 1;

    private int frame;//0 steady, 1 start grow, 2 finish grow, -1 start shrink, -2 finish shrink
    private float size = 1;

    public Color c;

	// Use this for initialization
	void Start () {
        //c = new Color(106f/255f, 208f/255f, 209f/255f, 173f/255f);
        trans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update () {
        switch(frame) {
            case 1:
                trans.localScale = size * 2f * trans.localScale;
                frame = 3;
                break;
            //case 2:
                //frame = 3;
                //break;
            case 3:
                frame = 4;
                break;
            case 4:
                trans.localScale = Mathf.Pow(1f/size, 1f/3f) * .9f * trans.localScale;
                frame = 5;
                break;
            case 5:
                trans.localScale = Mathf.Pow(1f/size, 1f/3f) *.83333333f * trans.localScale;
                frame = 6;
                break;
            case 6:
                GetComponent<Image>().color = c;
                trans.localScale = Mathf.Pow(1f/size, 1f/3f) * 2f/3f * trans.localScale;
                frame = 0;
                break;
        }
    }

    public void Beat(){
        Increment();
        if (beatCount == 1){ GetComponent<Image>().color= Color.red;}
        frame = 1;
    }

    public void Increment() {
        beatCount = (beatCount >= 4) ? 1 : beatCount + 1;
        t.text = beatCount.ToString();
    }
}
