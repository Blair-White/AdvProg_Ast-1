using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    public int TotalScore, PreviousScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = PreviousScore.ToString();
        if (PreviousScore != TotalScore)
            PreviousScore += 10;

    }




    public void AddScore(int level)
    {
        switch (level)
        {
            case 0:
                TotalScore += 150;
                break;

            case 1:
                TotalScore += 350;
                break;

            case 2:
                TotalScore += 750;
                break;

            case 3:
                TotalScore += 1250;
                break;
            default:
                break;
        }
    }

}
