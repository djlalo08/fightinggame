using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action {

    public int strength;
    public float range;
    public float offset;
    public string missName;

    override protected void Effect(){
        Player target = actor.enemy;
        float targPos = target.GetComponent<Transform>().position.x;
        float actorPos = actor.GetComponent<Transform>().position.x;
        if (Mathf.Abs(actorPos-targPos+offset) < range){
            target.Hit(strength);
            actor.GetComponent<Animator>().SetTrigger(actionName);
        }
        else{
            actor.GetComponent<Animator>().SetTrigger(missName);
        }
    }
}
