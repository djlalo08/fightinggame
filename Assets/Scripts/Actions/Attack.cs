using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action {

    public int strength;

    override protected void Effect(){
        Player target = actor.enemy;
        target.Hit(strength);
    }
}
