using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

    public Player actor;
    public float cost;
    public string actionName;
    public bool invert;

    public void Act(){
        actor.Fatigue(cost);
        Effect(); //there is an expectation that effect should trigger actionNam animation
    }

    protected abstract void Effect();

}
