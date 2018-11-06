using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

    public Player Actor;
	public abstract int cost(int frame);
    public abstract void Act();

}
