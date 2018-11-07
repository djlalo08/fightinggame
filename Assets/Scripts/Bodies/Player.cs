using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public string pName;

    public Text t;

    public Dictionary<string, Action> table = new Dictionary<string, Action>();
    public List<string> keys = new List<string>();
    public List<Action> vals = new List<Action>();

	public bool isEnemy;

	public Player enemy;
    KeyListener listener;

    public BodyPart rightArm;
    public BodyPart leftArm;
    public BodyPart leftLeg;
    public BodyPart rightLeg;
    public Heart heart;

    public double heartMax;
    public double heartPoints; 

    public double position;

	bool regen;
	public int updateCount = 0;

	// Use this for initialization
	void Awake() {
		
        heartMax = heart.MAX;
        heartPoints = heartMax;
		regen = true;

        foreach(Action a in vals){
            a.actor = this;
        }
        for (int i=0; i<keys.Count; i++){
            table.Add(keys[i], vals[i]);
        }
	}

    public void Regen(){
		if (regen){
            if (updateCount >= heart.RATE){
                heartPoints += heart.STRENGTH;
				updateCount = 0;
			}
			else{
				updateCount++;
			}
		}
        if (heartPoints > heartMax){
            heartPoints = heartMax;
		}
	}

	//take damage from a hit
    public void Hit(double strength, Player target){
		//TODO: factor in whether this player is facing the right dir. If sides, do bonus damage, if facing backwards do extra critical damage
        target.heartMax -= strength;
		if (heartPoints <= 0){
			//GameLoop.Knockout(pName);
		}
	}

    public void Fatigue(double weaken){
		heartPoints -= weaken;
		if (heartPoints <= 0) {heartPoints = 1;}
	}

	public void TieListener(KeyListener listener){
		this.listener = listener;
		listener.player = this;
	}

    public Action Parse(string str){
        int s = str.LastIndexOf("Space", StringComparison.CurrentCulture);
        if (s >= 0) str = str.Substring(s+5);
        t.text = str + " " + s.ToString();

        return !table.ContainsKey(str) ? table[""] : table[str];
    }

    public void Tire(){
        heartMax -= Mass()/heart.STAMINA;
    }

    public float Mass(){
        return rightArm.weight + leftArm.weight + rightLeg.weight + leftLeg.weight + heart.weight;
    }
}
