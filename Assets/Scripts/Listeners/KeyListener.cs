﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Possibly deprecated????????????? seems to be no use.....

//note that this class expects a player parameter:
//this is with multiplayer in mind:
//can use the same keylistener class, one instance for each player
public abstract class KeyListener : MonoBehaviour {

	public Player player;

    public bool isEnabled;

	protected string lastPressed;

	void Start(){
        lastPressed = "";
	}

	//called by GameLoop
	//RegistersCurrentKeyHits
	public abstract string GetInput();
}
