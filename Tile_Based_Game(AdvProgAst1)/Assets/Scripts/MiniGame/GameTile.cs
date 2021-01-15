using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{

    public GameObject GameController;
    public GameObject DialEffectPrefab;
    public GameObject up1, up2;
    public int TileNumber;
    public Sprite s0, s1, s2, s3;
    private int TileLevel; //0,1,2,3 minimum resources->max
    public bool isSet, isRevealed;
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


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Upgrade1")
        {

        }

        if(collision.gameObject.tag == "Upgrade2")
        {

        }

        if (collision.gameObject.tag == "ScanBox")
        {

        }
    }




}
