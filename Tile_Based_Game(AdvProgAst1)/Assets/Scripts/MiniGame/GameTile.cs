using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{

    public GameObject GameController;
    public GameObject DialEffectPrefab, MiningEffectPrefab;
    public int TileNumber, mRow, mColumn, MyResources;
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
                this.GetComponent<Image>().sprite = sprite1;
                isSet = true;
                MyResources = 250;
                break;
            case 2:
                this.GetComponent<Image>().sprite = sprite2;
                isSet = true;
                MyResources = 500;
                break;
            case 3:
                this.GetComponent<Image>().sprite = sprite3;
                isSet = true;
                MyResources = 1000;
                SetSurroundingTiles();
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
    

    }

    void SetSurroundingTiles()//this is a disaster lol. rafactor, but just get it working first. 
    {
        //Outer Layer
        if (AssessTile(TileNumber - 52, mRow - 2)) { SetOtherTile(TileNumber - 52, 1);}
        if (AssessTile(TileNumber - 51, mRow - 2)) { SetOtherTile(TileNumber - 51, 1);}
        if (AssessTile(TileNumber - 50, mRow - 2)) { SetOtherTile(TileNumber - 50, 1);}
        if (AssessTile(TileNumber - 49, mRow - 2)) { SetOtherTile(TileNumber - 49, 1);}
        if (AssessTile(TileNumber - 48, mRow - 2)) { SetOtherTile(TileNumber - 48, 1);}

        if (AssessTile(TileNumber - 27, mRow - 1)) { SetOtherTile(TileNumber - 27, 1);}
        if (AssessTile(TileNumber - 23, mRow - 1)) { SetOtherTile(TileNumber - 23, 1); }
        if (AssessTile(TileNumber - 2, mRow))      { SetOtherTile(TileNumber - 2, 1); }
        if (AssessTile(TileNumber + 2, mRow))      { SetOtherTile(TileNumber + 2, 1); }
        if (AssessTile(TileNumber + 27, mRow + 1)) { SetOtherTile(TileNumber + 27, 1); }
        if (AssessTile(TileNumber + 23, mRow + 1)) { SetOtherTile(TileNumber + 23, 1); }

        if (AssessTile(TileNumber + 52, mRow + 2)) { SetOtherTile(TileNumber + 52, 1); }
        if (AssessTile(TileNumber + 51, mRow + 2)) { SetOtherTile(TileNumber + 51, 1); }
        if (AssessTile(TileNumber + 50, mRow + 2)) { SetOtherTile(TileNumber + 50, 1); }
        if (AssessTile(TileNumber + 49, mRow + 2)) { SetOtherTile(TileNumber + 49, 1); }
        if (AssessTile(TileNumber + 48, mRow + 2)) { SetOtherTile(TileNumber + 48, 1); }

        //Inner Layer
        if (AssessTile(TileNumber - 26, mRow - 1)) { SetOtherTile(TileNumber - 26, 2); }
        if (AssessTile(TileNumber - 25, mRow - 1)) { SetOtherTile(TileNumber - 25, 2); }
        if (AssessTile(TileNumber - 24, mRow - 1)) { SetOtherTile(TileNumber - 24, 2); }

        if (AssessTile(TileNumber - 1, mRow)) { SetOtherTile(TileNumber - 1, 2); }
        if (AssessTile(TileNumber + 1, mRow)) { SetOtherTile(TileNumber + 1, 2); }

        if (AssessTile(TileNumber + 26, mRow + 1)) { SetOtherTile(TileNumber + 26, 2); }
        if (AssessTile(TileNumber + 25, mRow + 1)) { SetOtherTile(TileNumber + 25, 2); }
        if (AssessTile(TileNumber + 24, mRow + 1)) { SetOtherTile(TileNumber + 24, 2); }

    }

    bool AssessTile(int Tile, int Row)
    {
        if (Tile < 0 || Tile > 501) return false;
        if (GameController.GetComponent<MiniGameController>().GameTiles[Tile].GetComponent<GameTile>().mRow != Row) return false;
        return true;
    }

    void SetOtherTile(int gametile, int level)
    {
        GameController.GetComponent<MiniGameController>().GameTiles[gametile].GetComponent<GameTile>().TileLevel = level;
        GameController.GetComponent<MiniGameController>().GameTiles[gametile].GetComponent<GameTile>().SetTile(level);
    }
}
