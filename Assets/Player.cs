using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;
using System;

public class Player : MonoBehaviour {

    float x = 0, y = 0;
    float centerScreenBoxSize = 1f, lastPing = 0;

    // Update is called once per frame
    public void UpdatePosition(DataChange change, bool is_mine = false)
    {
        switch (change.path["axis"])
        {
            case "x":
                x = Convert.ToSingle(change.value) / 10;
                break;
            case "y":
                y = Convert.ToSingle(change.value) / 10;
                break;
            default:
                break;
        }
        if (is_mine)
        {
            float xDif = transform.position.x - Camera.main.transform.position.x;
            if (xDif > centerScreenBoxSize)
            {
                Camera.main.transform.position += (xDif - centerScreenBoxSize) * Vector3.right;
            }
            else if (xDif < -centerScreenBoxSize)
            {
                Camera.main.transform.position += (xDif + centerScreenBoxSize) * Vector3.right;
            }

            float yDif = transform.position.y - Camera.main.transform.position.y;
            if (yDif > centerScreenBoxSize)
            {
                Camera.main.transform.position += (yDif - centerScreenBoxSize) * Vector3.up;
            }
            else if (yDif < -centerScreenBoxSize)
            {
                Camera.main.transform.position += (yDif + centerScreenBoxSize) * Vector3.up;
            }
        }
        float ping = Time.time - lastPing;
        if (ping < 0.1f)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (ping < 0.2f)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if (ping < 0.3f)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (ping < 0.4f)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (ping < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (ping < 0.75f)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else if (ping < 1f)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        lastPing = Time.time;
    }

    void Update(){
        transform.position = new Vector2(x, y);
    }
}
