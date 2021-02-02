using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedBackPrefab : MonoBehaviour
{
    public GameObject oText, mgr;
    public string mText;
    private float delayRewind;
    public bool isMining;
    public int level;
    private int textchoice;
    public string[] myMiningTexts, myScanningTexts; //lvl 111,222,333. 
    // Start is called before the first frame update


    void Start()
    {
       mgr = GameObject.Find("GameController");
       
        oText.GetComponent<TextMeshProUGUI>().text = mText;
        textchoice = Random.Range(0, 2);
        if(isMining)
        {
            oText.GetComponent<TextMeshProUGUI>().text = this.myMiningTexts[level*3+textchoice];
        }
        else
        {
            oText.GetComponent<TextMeshProUGUI>().text = this.myScanningTexts[level * 3 + textchoice];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mgr.GetComponent<MiniGameController>().State == MiniGameController.States.EndGame)
            Destroy(gameObject);
            
        delayRewind += Time.deltaTime;
        if (delayRewind >= 3)
        {
            GameObject g = GameObject.Find("GameController");
            g.GetComponent<MiniGameController>().MiningFeedbackLevel = 0;
            g.GetComponent<MiniGameController>().ScanningFeedbackLevel = 0;
            Destroy(this.gameObject);
        }
            
    }
}
