using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

    public Player actor;
    public float cost;
    public string actionName;
    public string invName; //inverse action

    public void Fatigue(){
        actor.Fatigue(cost);
    }

    public void Act(){
        Effect(); //there is an expectation that effect should trigger actionNam animation
    }

    protected abstract void Effect();

}
