using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{

    public GameObject GameController;
    public GameObject DialEffectPrefab, MiningEffectPrefab;
    public GameObject up1, up2;
    public int TileNumber, MyResources;
    public Sprite sprite0, sprite1, sprite2, sprite3;
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
        if(GameController.GetComponent<MiniGameController>().State == MiniGameController.States.ExtractMode)
        {
            Instantiate(MiningEffectPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }

    }

    public void SetTile(int level)
    {
        switch (level)
        {
            case 0:
                this.GetComponent<Image>().sprite = sprite0;
                isSet = true;
                MyResources = 100;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                this.GetComponent<Image>().sprite = sprite3;
                isSet = true;
                MyResources = 1000;
                up1.SetActive(true); up2.SetActive(true);
                break;
            default:
                break;
        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "ScanBox")
        {
            this.isRevealed = true;
        }

        if (collision.gameObject.tag == "MiningBox")
        {


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isSet) return;
        if (collision.gameObject.tag == "Upgrade1")
        {
            this.GetComponent<Image>().sprite = sprite1;
            isSet = true;
           
        }

        if (collision.gameObject.tag == "Upgrade2")
        {
            this.GetComponent<Image>().sprite = sprite2;
            isSet = true;
            
        }

    }



}
