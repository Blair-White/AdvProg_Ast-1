using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public enum States    { 
        StartSetup, FinishSetup, EnterLocked, Locked, EnterIdle, Idle, 
        EnterScan, ScanMode, EnterExtract, ExtractMode, EnterEnd, EndGame
                          }
    public States State = States.Locked;
    public GameObject[] GameTiles;
    public GameObject[] ChosenTiles;
    public GameObject ScoreText, ScorePopupPrefab, FeedBackPrefab; 
    private int TilesChosen;
    private bool DistanceFailed;
    public int MiningFeedbackLevel, ScanningFeedbackLevel;
    // Start is called before the first frame update
    void Start()
    {
        State = States.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case States.StartSetup:
                ChooseTile();
                if (TilesChosen > 5) State = States.FinishSetup;
                break;
            case States.FinishSetup:
                Debug.Log("Finished Setup");
                SetAllUnMarked();
                State = States.Idle;
                break;
            case States.EnterLocked:
                break;
            case States.Locked:
                break;
            case States.EnterIdle:

                break;
            case States.Idle:
                break;
            case States.EnterScan:
                break;
            case States.ScanMode:
                break;
            case States.EnterExtract:
                break;
            case States.ExtractMode:
                break;
            case States.EnterEnd:
                break;
            case States.EndGame:
                break;
            default:
                break;
        }
    }




    void ChooseTile()
    {
        DistanceFailed = false;
        if(TilesChosen == 0)
        {
            int r = Random.Range(0, 499);
            GameTiles[r].SendMessage("SetTile", 3);
            ChosenTiles[0] = GameTiles[r];
            TilesChosen++;
        }
        else
        {
            int r = Random.Range(0, 499);
            if (GameTiles[r].GetComponent<GameTile>().isSet) ChooseTile();
            else
            if (!GameTiles[r].GetComponent<GameTile>().isSet)
            {
                for(int i = 0; i < ChosenTiles.Length; i++)
                {
                    if (ChosenTiles[i] != null) CheckTileDistance(ChosenTiles[i], GameTiles[r]);
                }
                if (DistanceFailed == false)
                {
                    GameTiles[r].SendMessage("SetTile", 3);
                    ChosenTiles[TilesChosen] = GameTiles[r];
                    TilesChosen++;
                    return;
                }
                else return;
            }
        }

    }
    bool CheckTileDistance(GameObject a, GameObject b)
    {
        if (Vector3.Distance(a.transform.position, b.transform.position) >= 3)
        {
            return true;
        }
        else
        {
            DistanceFailed = true;
            return false;
        }
           
        
    }

    void ConfirmTile()
    {

    }

    void UpgradeTile()
    {

    }

    void SetAllUnMarked()
    {
        for(int i = 0; i < GameTiles.Length; i++)
        {
            if(!GameTiles[i].GetComponent<GameTile>().isSet)
            {
                GameTiles[i].SendMessage("SetTile", 0, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
