using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameController : MonoBehaviour
{
    public enum States    { 
        StartSetup, FinishSetup, EnterLocked, Locked, EnterIdle, Idle, 
        EnterScan, ScanMode, EnterExtract, ExtractMode, EnterEnd, EndGame
                          }
    public States State = States.Locked;
    public GameObject[] GameTiles;
    public GameObject[] ChosenTiles;
    public GameObject ScoreText, ScorePopupPrefab, FeedBackPrefab, ExtractButton, ScanningButton, ExtractsRemaining, ScansRemaining; 
    private int TilesChosen;
    private bool DistanceFailed;
    public int MiningFeedbackLevel, ScanningFeedbackLevel;
    public Color HighlightButton, UnHighlightButton;

    public int mines, scans;
    // Start is called before the first frame update
    void Start()
    {
        State = States.Locked;
        mines = 3;
        scans = 6;
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
                State = States.EnterExtract;
                ScanningButton.GetComponent<Image>().color = UnHighlightButton;
                ExtractButton.GetComponent<Button>().enabled = true;
                ScanningButton.GetComponent<Button>().enabled = true;
                break;
            case States.EnterLocked:
                ExtractButton.GetComponent<Image>().color = UnHighlightButton;
                ScanningButton.GetComponent<Image>().color = UnHighlightButton;
                ExtractButton.GetComponent<Button>().enabled = false;
                ScanningButton.GetComponent<Button>().enabled = false;
                
                State = States.Locked;
                break;
            case States.Locked:
                break;
            case States.EnterIdle:
                ExtractButton.GetComponent<Button>().enabled = true;
                ScanningButton.GetComponent<Button>().enabled = true;
                ExtractButton.GetComponent<Image>().color = UnHighlightButton;
                ScanningButton.GetComponent<Image>().color = UnHighlightButton;
                break;
            case States.Idle:
                break;
            case States.EnterScan:
                ExtractButton.GetComponent<Image>().color = UnHighlightButton;
                ScanningButton.GetComponent<Image>().color = HighlightButton;
                State = States.ScanMode;
                break;
            case States.ScanMode:
                break;
            case States.EnterExtract:
                ExtractButton.GetComponent<Image>().color = HighlightButton;
                ScanningButton.GetComponent<Image>().color = UnHighlightButton;
                State = States.ExtractMode;
                break;
            case States.ExtractMode:
                break;
            case States.EnterEnd:
                ExtractButton.gameObject.SetActive(false);
                ScanningButton.gameObject.SetActive(false);
                break;
            case States.EndGame:
                break;
            default:
                break;
        }
    }

    public void MiningPushed()
    {
        State = States.EnterExtract;
    }

    public void ScanningPushed()
    {
        State = States.EnterScan;
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
