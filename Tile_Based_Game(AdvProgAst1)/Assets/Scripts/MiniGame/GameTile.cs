using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{

    public GameObject GameController;
    public GameObject DialEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TileClicked()
    {
        if(GameController.GetComponent<MiniGameController>().State == MiniGameController.States.ScanMode)
        {
            Instantiate(DialEffectPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
    
    }
}
