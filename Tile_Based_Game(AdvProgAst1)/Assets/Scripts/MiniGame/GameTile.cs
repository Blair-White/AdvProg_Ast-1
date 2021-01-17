using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{

    public GameObject GameController;
    public GameObject DialEffectPrefab, MiningEffectPrefab;
    public int TileNumber, mRow, mColumn, MyResources;
    public Sprite sprite0, sprite1, sprite2, sprite3, myRevealedSprite;
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
            I_Drink_Your_MilkShake();
            isSet = false;
            this.SetTile(0);
            RevealTile();
            Instantiate(MiningEffectPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }

    }

    public void SetTile(int level)
    {
        if (isSet) return;
        switch (level)
        {
            case -1:
                isSet = true;
                break;
            case -2:
                isSet = true;
                break;
            case 0:
                myRevealedSprite = sprite0;
                isSet = true;
                MyResources = 100;
                TileLevel = 0;
                break;
            case 1:
                myRevealedSprite = sprite1;
                isSet = true;
                MyResources = 250;
                TileLevel = 1;
                break;
            case 2:
                myRevealedSprite = sprite2;
                isSet = true;
                MyResources = 500;
                TileLevel = 2;
                break;
            case 3:
                myRevealedSprite = sprite3;
                isSet = true;
                MyResources = 1000;
                TileLevel = 3;
                SetSurroundingTiles();
                break;
            default:
                break;
        }

    }

    void RevealTile()
    {
        this.GetComponent<Image>().sprite = myRevealedSprite;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "ScanBox")
        {
            this.isRevealed = true;
            RevealTile();
        }

        if (collision.gameObject.tag == "MiningBox")
        {
            this.SetTile(this.TileLevel - 1);
            RevealTile();
        }
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

    void I_Drink_Your_MilkShake()
    {
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 52].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 51].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 50].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 49].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 48].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 27].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 23].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber -  2].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber +  2].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 27].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 23].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 52].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 52].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 51].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 50].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 49].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 48].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 26].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 25].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber - 24].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber -  1].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber +  1].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 26].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 25].GetComponent<GameTile>().isSet = false;
        GameController.GetComponent<MiniGameController>().GameTiles[TileNumber + 24].GetComponent<GameTile>().isSet = false;
    }

    bool AssessTile(int Tile, int Row)
    {
        if (Tile < 0 || Tile > 501) return false;
        if (GameController.GetComponent<MiniGameController>().GameTiles[Tile].GetComponent<GameTile>().mRow != Row) return false;
        if (GameController.GetComponent<MiniGameController>().GameTiles[Tile].GetComponent<GameTile>().mRow < 0
            ||
            (GameController.GetComponent<MiniGameController>().GameTiles[Tile].GetComponent<GameTile>().mRow > 20))
            return false;
        return true;
    }

    void SetOtherTile(int gametile, int level)
    { 
        GameController.GetComponent<MiniGameController>().GameTiles[gametile].GetComponent<GameTile>().SetTile(level);
    }
}
