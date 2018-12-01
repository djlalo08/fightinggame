﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : Action {

    protected override void Effect(){
        Transform t = actor.GetComponent<Transform>();
        actor.facingRight = !actor.facingRight;
        t.eulerAngles = t.eulerAngles+ new Vector3(0,180f,0);
    }

}
