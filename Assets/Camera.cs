using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Transform t;
    public float speed;
    // Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 pos = t.localPosition;
        t.localPosition = new Vector3(pos.x, pos.y, pos.z+speed);
        if (pos.z > -9.5) speed = 0;
    }
}
