﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileContainerStart : MonoBehaviour
{
    private int delayCount, spawnCount, rowCount;
    private bool initialized;
    public GameObject GameTile;
    private GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");   
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized)
        {
            delayCount++;
            if(delayCount > 5)
            {
                GameObject g = Instantiate(GameTile, this.transform);
                g.transform.position = 
                    new Vector3
                    (
                    this.transform.position.x + spawnCount * .45f, 
                    this.transform.position.y + rowCount * .45f, 
                    0
                    );
                delayCount = 0;
                spawnCount++;
            }
            if(spawnCount > 24)
            {
                rowCount--;
                spawnCount = 0;
               
            }
            if(rowCount <= -20)
            {
                initialized = true;
                Debug.Log("init complete");
                GameController.GetComponent<MiniGameController>().State = MiniGameController.States.StartSetup;
            }
        }
    }
}
