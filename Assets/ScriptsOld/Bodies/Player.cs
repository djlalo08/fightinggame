using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public string pName;

	public Hashtable table = new Hashtable();

	public bool isEnemy;

	public Player enemy;
    public KeyListener listener;

    public BodyPart rightArm;
    public BodyPart leftArm;
    public BodyPart leftLeg;
    public BodyPart rightLeg;
    public Heart heart;

    public double heartPoints; 

    public double position;

	bool regen;
	public int updateCount = 0;

	public GameEvent performing;
	// Use this for initialization
	void Awake() {
		
		heartPoints = heart.MAX;

		regen = true;
        int i = 0;
		BodyPart[] limbs = new BodyPart[]{rightArm, leftArm, rightLeg, leftLeg};
		foreach (BodyPart bp in limbs){
			foreach (Action a in bp.attacks){
                string s = i.ToString();
                i++;
                if (!table.ContainsKey(s)){
                    table.Add(s, a);
                }
			}
			foreach (Action a in bp.moves){
                string s = i.ToString();
				if (!table.ContainsKey(s)){
					table.Add(s, a);
				}
                i++;
			}
		}
		foreach (string s in table.Keys){
			print(s);
		}
	}

	public void update(){
		//addHeart();
		//you can always do any action, and it will just bring your heart points down to 1 until next update cycle
		//except some attacks have a minimum-points cutoff
		//turn regen off during an attack/motion
		//pendingAction();
	}

    public void Regen(){
		if (regen){
			if (updateCount >= heart.tempo()){
				heartPoints += heart.beat();
				updateCount = 0;
			}
			else{
				updateCount++;
			}
		}
		heart.update();
		if (heartPoints > heart.getPointMax()){
			heartPoints = heart.getPointMax();
		}
	}

	//take damage from a hit
	public void Hit(double strength, double weaken){
		//TODO: factor in whether this player is facing the right dir. If sides, do bonus damage, if facing backwards do extra critical damage
		heart.decrease(strength);
		heartPoints -= weaken;
		if (heartPoints <= 0){
			GameLoop.Knockout(pName);
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

    public Action Listen(){

		if (isEnemy) 
			return null; //TODO implement AI

		if (Input.inputString.Length > 0){

			List<char> keys = new List<char>();
			foreach (char c in Input.inputString){
				keys.Add(c);
			}
			keys.Sort();

			string s = "";
			foreach (char c in keys){
				s += c;
			}

            if (s.Length > 0){
				print("Keystring [" + s + "] has been pressed");
			}

			return (Action)table[s];
		}
		return null;
	}

	//Take move that has been keyed in and charge for it
    public void PendingAction(){
		//always do move, bring heartPoints as low as 1, if need be
		Action pendingAction = Listen();
			
		if (pendingAction == null) {
			//No valid keys pressed
		}
			
		else if (pendingAction is Attack) {
			AttackEvent e = new AttackEvent ((Attack)pendingAction, this, enemy);
			GameLoop.AddToList (e);
			performing = e;
		}

		else if (pendingAction is Move) {
			MoveEvent e = new MoveEvent (this, (Move)pendingAction);
			GameLoop.AddToList (e);
			performing = e;
		}
	}

    public Action Parse(string str){
        return new Nothing();
    }
}
