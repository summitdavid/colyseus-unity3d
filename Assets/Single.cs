using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Colyseus;

public class Single : MonoBehaviour {

    Player player;
    public GameObject playerPrefab;
    Double setX1 = 0, setY1 = 0, x = 0, y = 0;

	// Use this for initialization
	void Start () {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
	}
	
	// Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            setX1--;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            setX1++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setX1++;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            setX1--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            setY1--;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            setY1++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setY1++;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            setY1--;
        }
        x += setX1 / 2;
        y += setY1 / 2;


        DataChange change = new DataChange();
        change.value = x;
        change.path = new Dictionary<string, string>();
        change.path.Add("axis", "x");
        player.UpdatePosition(change);


        change.value = y;
        change.path["axis"] = "y";
        player.UpdatePosition(change, true);
	}
}
