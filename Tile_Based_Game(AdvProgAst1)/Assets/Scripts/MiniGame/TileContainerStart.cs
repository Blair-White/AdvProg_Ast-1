using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileContainerStart : MonoBehaviour
{
    private int delayCount, spawnCount, rowCount;
    private bool initialized;
    public GameObject GameTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized)
        {
            delayCount++;
            if(delayCount > 35)
            {
                GameObject g = Instantiate(GameTile, this.transform);
                g.transform.position = 
                    new Vector3
                    (
                    this.transform.position.x + spawnCount * 1, 
                    this.transform.position.y + rowCount, 
                    0
                    );
                delayCount = 0;
                spawnCount++;
            }
            if(spawnCount > 12)
            {
                rowCount--;
                spawnCount = 0;
               
            }
            if(rowCount <= -10)
            {
                initialized = true;
                Debug.Log("init complete");
            }
        }
    }
}
