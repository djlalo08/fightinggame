using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Action {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Act() {
        //Do nothing
    }

    override public int cost(int frame) {
        return 0;
    }
}
