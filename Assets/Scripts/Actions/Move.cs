using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Action {

    public float dir;

    protected override void Effect() {
        if (actor.heartPoints> cost){
            actor.GetComponent<Transform>().localPosition = actor.GetComponent<Transform>().localPosition + new Vector3(dir,0,0);

        }
    }
}
