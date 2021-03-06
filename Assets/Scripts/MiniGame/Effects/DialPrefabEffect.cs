﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialPrefabEffect : MonoBehaviour
{
    private int destroyCount;
    public bool isMining;
    private int delaysound;
    private GameObject mgr;
    public GameObject FeedbackPrefab;
    private void Awake()
    {
        mgr = GameObject.Find("GameController");
        mgr.GetComponent<MiniGameController>().State = MiniGameController.States.EnterLocked;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        delaysound++;
        if(delaysound == 2)
        {
            if (isMining)
            {
                SFXController.instance.PlayMining();
                mgr.GetComponent<MiniGameController>().mines--;
                mgr.GetComponent<MiniGameController>().ExtractsRemaining.GetComponent<TextMeshProUGUI>().text = mgr.GetComponent<MiniGameController>().mines.ToString();                
            }
            else 
            { 
                SFXController.instance.PlayScanning();
                mgr.GetComponent<MiniGameController>().scans--;
                mgr.GetComponent<MiniGameController>().ScansRemaining.GetComponent<TextMeshProUGUI>().text = mgr.GetComponent<MiniGameController>().scans.ToString();
               
            }
        }
        destroyCount++;
        if (destroyCount > 420)
        {
                       
            mgr.GetComponent<MiniGameController>().State = MiniGameController.States.EnterIdle;
            GameObject g = Instantiate(FeedbackPrefab);
            if(isMining)
            {
                g.GetComponent<FeedBackPrefab>().isMining = isMining;
                g.GetComponent<FeedBackPrefab>().level = mgr.GetComponent<MiniGameController>().MiningFeedbackLevel;
            }
            else
            {
                g.GetComponent<FeedBackPrefab>().isMining = isMining;
                g.GetComponent<FeedBackPrefab>().level = mgr.GetComponent<MiniGameController>().ScanningFeedbackLevel;
            }

            GameObject.Destroy(this.gameObject);
        }  
            
        this.transform.Rotate(0, 0, this.transform.rotation.z + 1);
    }
}
