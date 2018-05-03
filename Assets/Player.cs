﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;

public class Player : MonoBehaviour {

    float x = 0, y = 0;
	
	// Update is called once per frame
    public void UpdatePosition (DataChange change) {
        switch(change.path["axis"]){
            case "x":
                x = (float)change.value / 10;
                break;
            case "y":
                y = (float)change.value / 10;
                break;
            default:
                break;
        }
	}

    void Update(){
        transform.position = new Vector2(x, y);
    }
}
