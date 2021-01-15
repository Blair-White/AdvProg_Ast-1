using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public enum States    { StartSetup, FinishSetup, EnterLocked, Locked, EnterScan, ScanMode, EnterExtract, ExtractMode, EnterEnd, EndGame }
    public States State = States.Locked;
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
                break;
            case States.FinishSetup:
                break;
            case States.EnterLocked:
                break;
            case States.Locked:
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

}
