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
        Player current = actor;
        Player target = actor.enemy;
        float targPos = target.GetComponent<Transform>().position.x;
        float actorPos = actor.GetComponent<Transform>().position.x;


        float trueOffset = current.facingRight? offset: -offset;

        //This makes sure that if you're in the front and facing right, you hit to the right, and if you're facing left, you hit to the left.
        if (front)
        {
            if (Mathf.Abs(actorPos - targPos + trueOffset) < range)
            {
                target.Hit(strength);
                if (current.facingRight)
                {
                    //If facing right and you use the left attack key, flip the character.
                    if(current.getActions().Contains("Q")){
                        Action paction = current.Parse("S");
                        paction.Act();
                    }
                    //Opens certain animator animations based on the call set by buttons
                    current.GetComponent<Animator>().SetTrigger(actionName);
                }
                else
                {   //If you're facing left and you hit the right attack key, flip the character.
                    if(current.getActions().Contains("E")){
                        Action paction = current.Parse("S");
                        paction.Act();
                    }
                    current.GetComponent<Animator>().SetTrigger(invName);
                }
            }
            else
            {
                current.GetComponent<Animator>().SetTrigger(missName);
            }
        }

        //This does the same to the player in the back. facing left hits left, facing right hits right, so you can actually hit the other player. 
        else
        {

            if (Mathf.Abs(targPos - actorPos + trueOffset) < range)
            {
                target.Hit(strength);
                if (current.facingRight)
                {
                    //Opens certain animator animations based on the call set by buttons
                    current.GetComponent<Animator>().SetTrigger(actionName);
                }
                else
                {
                    current.GetComponent<Animator>().SetTrigger(invName);
                }
            }
            else
            {
                current.GetComponent<Animator>().SetTrigger(missName);
            }
        }
    }
}
