using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

    public Player actor;
    public float cost;

    public void Act(){
        if (cost < actor.heartPoints){
            actor.Fatigue(cost);
            Effect();
        }
    }

    protected abstract void Effect();

}
