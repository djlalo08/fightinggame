using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : Action {

    public int strength;
    public float range;
    public float offset;
    public string missName;
    public bool front;
    override protected void Effect(){

        //Try to figure out how to figure out whether the direction you are facing is opposite of the attack key you press so that you can flip. 
        front = actor.isFront;
        Player target = actor.enemy;
        float targPos = target.GetComponent<Transform>().position.x;
        float actorPos = actor.GetComponent<Transform>().position.x;


        float trueOffset = actor.facingRight? offset: -offset;

        if (front)
        {
            if ((Input.GetKeyDown(KeyCode.Q) && actor.facingRight) || (Input.GetKeyDown(KeyCode.E) && !actor.facingRight)){

            }

            if (Mathf.Abs(actorPos - targPos + trueOffset) < range)
            {
                target.Hit(strength);
                if (actor.facingRight)
                {
                    //Opens certain animator animations based on the call set by buttons
                    actor.GetComponent<Animator>().SetTrigger(actionName);
                }
                else
                {
                    actor.GetComponent<Animator>().SetTrigger(invName);
                }
            }
            else
            {
                actor.GetComponent<Animator>().SetTrigger(missName);
            }
        }

        else
        {
            if ((Input.GetKeyDown(KeyCode.I) && actor.facingRight) || (Input.GetKeyDown(KeyCode.P) && !actor.facingRight)){

            }

            if (Mathf.Abs(targPos - actorPos + trueOffset) < range)
            {
                target.Hit(strength);
                if (actor.facingRight)
                {
                    //Opens certain animator animations based on the call set by buttons
                    actor.GetComponent<Animator>().SetTrigger(actionName);
                }
                else
                {
                    actor.GetComponent<Animator>().SetTrigger(invName);
                }
            }
            else
            {
                actor.GetComponent<Animator>().SetTrigger(missName);
            }
        }
    }
}
