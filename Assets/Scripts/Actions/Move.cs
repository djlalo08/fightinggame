using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Action {

    public float dir;
    public readonly float lim = 7f;

    protected override void Effect() {
        Transform trans = actor.GetComponent<Transform>();
        if (actor.heartPoints> cost){
            Vector3 oldPos = trans.localPosition;
            trans.localPosition = trans.localPosition + new Vector3(dir,0,0);
            float x = trans.localPosition.x;
            if (x< -lim || x > lim) trans.localPosition = oldPos;
        }
        actor.GetComponent<Animator>().SetTrigger(actionName);
    }
}
