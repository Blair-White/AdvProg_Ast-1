using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public enum States    {  Locked, ScanMode, ExtractMode, EndGame }
    public States State = States.Locked;
    // Start is called before the first frame update
    void Start()
    {
        //test
        State = States.ScanMode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
