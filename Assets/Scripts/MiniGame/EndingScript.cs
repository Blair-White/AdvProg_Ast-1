using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndingScript : MonoBehaviour
{
    public int endScore, perfectscans, perfectmines;
    private string low, medium, high;
    public GameObject viabilityText, scoreText, FeedbackText, gamescore;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        low = "May the great machine have mercy on our colony.";
        medium = "The Colony has sufficient resources to survive.";
        high = "This Colony will become a shining beacon for the federation.";
        gamescore = GameObject.Find("ScoreText");
        endScore = gamescore.GetComponent<ScoreText>().TotalScore;
        scoreText.GetComponent<TextMeshProUGUI>().text = endScore.ToString();
        if (endScore < 2000)
        {
            viabilityText.GetComponent<TextMeshProUGUI>().text = "Near Impossible";
            FeedbackText.GetComponent<TextMeshProUGUI>().text = low;
        }      
        if (endScore >1999 && endScore < 3000)
        {
            viabilityText.GetComponent<TextMeshProUGUI>().text = "Sustainable";
            FeedbackText.GetComponent<TextMeshProUGUI>().text = medium;

        }
        if(endScore > 2999)
        {

            viabilityText.GetComponent<TextMeshProUGUI>().text = "Excellent";
            FeedbackText.GetComponent<TextMeshProUGUI>().text = high;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 8)
        {
            SceneManager.LoadScene(0);
        }
    }
}
