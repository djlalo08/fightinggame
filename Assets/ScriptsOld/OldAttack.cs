using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAttack : Action {

	public int[] weakenList; //number heart points removed each frame
	public int[] costList; //cost at each frame
	public int[] strengthList; //How much damage attack should deal during a given frame (this should generally be 0 for most frames, and a high number for the last few).
	public int speed; //number of frames it takes to execute

	// Use this for initialization
	void Start () {
	
	}

	public int weaken(int frame){
		return weakenList[frame];
	}

	public int strength(int frame){
		return strengthList[frame];
	}

	public int evalCost(int frame){
		return costList[frame];
	}

    override public void Act(){

    }
}
